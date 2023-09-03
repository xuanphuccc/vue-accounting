using AutoMapper;
using MISA.AmisMintax.Domain;
using MISA.AmisMintax.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class EmployeeService : BaseCodeService<Employee, Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeManager _employeeManager;
        private readonly IEmployeeRelationshipRepository _employeeRelationshipRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeManager employeeManager, IEmployeeRelationshipRepository employeeRelationshipRepository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(employeeRepository, unitOfWork, mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeManager = employeeManager;
            _employeeRelationshipRepository = employeeRelationshipRepository;
        }

        /// <summary>
        /// Tìm kiếm, filter và phân trang
        /// </summary>
        /// <param name="search">Search theo tên hoặc mã nhân viên</param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<Pagination> FilterAsync(EmployeeFilterDto employeeFilterDto)
        {
            var employeeFilterModel = _mapper.Map<EmployeeFilterModel>(employeeFilterDto);

            var pagedEmployees = await _employeeRepository.FilterAsync(employeeFilterModel);

            pagedEmployees.Data = _mapper.Map<IEnumerable<EmployeeDto>>(pagedEmployees.Data);

            return pagedEmployees;
        }

        /// <summary>
        /// Đếm số bản ghi đang được sử dụng
        /// </summary>
        /// <returns>Số bản ghi đang được sử dụng và tổng số bản ghi</returns>
        /// CreatedBy: txphuc (25/08/2023)
        public async Task<UsageCount> GetUsageCountAsync()
        {
            var usageCount = await _employeeRepository.GetUsageCountAsync();

            return usageCount;
        }


        /// <summary>
        /// Xử lý chỉnh sửa dữ liệu theo yêu cầu
        /// </summary>
        /// <param name="employeeDto">Đối tượng cần chỉnh sửa</param>
        /// CreatedBy: txphuc (22/08/2023)
        public override async Task CustomDetailData(EmployeeDto employeeDto)
        {
            // Thêm thông tin người thân cho nhân viên
            var employeeRelationships = await _employeeRelationshipRepository.GetListByEmployeeIdAsync(new List<Guid>() { employeeDto.EmployeeID });

            var employeeRelationshipDtos = _mapper.Map<IEnumerable<EmployeeRelationshipDto>>(employeeRelationships);

            employeeDto.EmployeeRelationships = employeeRelationshipDtos.ToList();
        }

        /// <summary>
        /// Validate nghiệp vụ cho Insert
        /// </summary>
        /// <param name="entityCreateDto">CreateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override async Task<Employee> MapCreateDtoToEntityAsync(EmployeeCreateDto entityCreateDto)
        {
            // Check trùng mã
            await _employeeManager.CheckExistEmployeeCode(entityCreateDto.EmployeeCode);

            // Check trùng mã số thuế
            await _employeeManager.CheckExistTaxCode(entityCreateDto.TaxCode);

            // Check trùng số CMND/CCCD/Hộ chiếu
            await _employeeManager.CheckExistIdentifyNumber(entityCreateDto.IdentifyNumber);

            var employee = _mapper.Map<Employee>(entityCreateDto);

            employee.EmployeeID = Guid.NewGuid();

            return employee;
        }

        /// <summary>
        /// Validate nghiệp vụ cho Update
        /// </summary>
        /// <param name="employeeId">Id của bản ghi</param>
        /// <param name="entityUpdateDto">UpdateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override async Task<Employee> MapUpdateDtoToEntityAsync(Guid employeeId, EmployeeUpdateDto entityUpdateDto)
        {
            // Check nhân viên có tồn tại hay không
            var oldEmployee = await _employeeRepository.GetByIdAsync(employeeId);

            // Check trùng mã
            await _employeeManager.CheckExistEmployeeCode(entityUpdateDto.EmployeeCode, oldEmployee.EmployeeCode);

            // Check trùng mã số thuế
            await _employeeManager.CheckExistTaxCode(entityUpdateDto.TaxCode, oldEmployee.TaxCode);

            // Check trùng số CMND/CCCD/Hộ chiếu
            await _employeeManager.CheckExistIdentifyNumber(entityUpdateDto.IdentifyNumber, oldEmployee.IdentifyNumber);

            var employee = _mapper.Map(entityUpdateDto, oldEmployee);

            return employee;
        }

        /// <summary>
        /// Insert các bảng phụ
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// CreatedBy: txphuc (23/08/2023)
        protected override async Task InsertDetailTableAsync(EmployeeCreateDto employeeCreateDto, Guid employeeId)
        {
            if (employeeCreateDto.EmployeeRelationships.Count > 0)
            {
                var employeeRelationShips = _mapper.Map<IEnumerable<EmployeeRelationship>>(employeeCreateDto.EmployeeRelationships);

                foreach (var employeeRelationship in employeeRelationShips)
                {
                    employeeRelationship.EmployeeRelationshipID = Guid.NewGuid();
                    employeeRelationship.EmployeeID = employeeId;

                    // Thêm ngày tạo
                    employeeRelationship.CreatedDate = DateTime.Now;
                    employeeRelationship.CreatedBy = "txphuc";
                    employeeRelationship.ModifiedDate = DateTime.Now;
                    employeeRelationship.ModifiedBy = "txphuc";
                }

                await _employeeRelationshipRepository.InsertMultipleAsync(employeeRelationShips);
            }
        }

        /// <summary>
        /// Update các bảng phụ (nếu có)
        /// </summary>
        /// <param name="entityUpdateDto">Data</param>
        /// <param name="entityId">Id của bảng chính</param>
        /// <returns></returns>
        /// CreatedBy: txphuc (23/08/2023)
        protected override async Task UpdateDetailTableAsync(EmployeeUpdateDto employeeUpdateDto, Guid employeeId)
        {
            if (employeeUpdateDto.EmployeeRelationships.Count > 0)
            {
                List<EmployeeRelationship> insertList = new();
                List<EmployeeRelationship> updateList = new();
                List<Guid> deleteList = new();

                foreach (var employeeRelationshipDto in employeeUpdateDto.EmployeeRelationships)
                {
                    var employeeRelationship = _mapper.Map<EmployeeRelationship>(employeeRelationshipDto);

                    employeeRelationship.EmployeeID = employeeId;

                    var editMode = employeeRelationshipDto.EditMode;

                    switch (editMode)
                    {
                        // Thêm mới
                        case EditMode.Create:
                            employeeRelationship.EmployeeRelationshipID = Guid.NewGuid();

                            insertList.Add(employeeRelationship);

                            // Thêm ngày tạo
                            employeeRelationship.CreatedDate = DateTime.Now;
                            employeeRelationship.CreatedBy = "txphuc";
                            employeeRelationship.ModifiedDate = DateTime.Now;
                            employeeRelationship.ModifiedBy = "txphuc";
                            break;

                        // Cập nhật
                        case EditMode.Update:
                            updateList.Add(employeeRelationship);

                            // Cập nhật ngày sửa
                            employeeRelationship.ModifiedDate = DateTime.Now;
                            employeeRelationship.ModifiedBy = "txphuc";
                            break;

                        // Xoá
                        case EditMode.Delete:
                            deleteList.Add(employeeRelationship.EmployeeRelationshipID);
                            break;
                    }
                }

                if (insertList.Count > 0)
                {
                    await _employeeRelationshipRepository.InsertMultipleAsync(insertList);
                }

                if (updateList.Count > 0)
                {
                    await _employeeRelationshipRepository.UpdateMultipleAsync(updateList);
                }

                if (deleteList.Count > 0)
                {
                    await _employeeRelationshipRepository.DeleteMultipleAsync(deleteList);
                }
            }
        }
    }
}

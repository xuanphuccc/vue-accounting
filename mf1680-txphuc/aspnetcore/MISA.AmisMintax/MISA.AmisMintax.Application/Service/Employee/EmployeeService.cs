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
    public class EmployeeService : BaseCodeService<Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeRelationshipRepository _employeeRelationshipRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeRelationshipRepository employeeRelationshipRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(employeeRepository, unitOfWork, mapper)
        {
            _employeeRepository = employeeRepository;
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
        /// Xử lý chỉnh sửa dữ liệu theo yêu cầu
        /// </summary>
        /// <param name="employeeDto">Đối tượng cần chỉnh sửa</param>
        /// CreatedBy: txphuc (22/08/2023)
        public override async Task CustomDetailData(EmployeeDto employeeDto)
        {
            // Thêm thông tin người thân cho nhân viên
            var employeeRelationships = await _employeeRelationshipRepository.GetListByEmployeeIdAsync(employeeDto.EmployeeID);

            var employeeRelationshipDtos = _mapper.Map<IEnumerable<EmployeeRelationshipDto>>(employeeRelationships);

            employeeDto.EmployeeRelationships = employeeRelationshipDtos.ToList();
        }

        /// <summary>
        /// Validate nghiệp vụ cho Insert
        /// </summary>
        /// <param name="entityCreateDto">CreateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override Task<Employee> MapCreateDtoToEntityAsync(EmployeeCreateDto entityCreateDto)
        {
            var employee = _mapper.Map<Employee>(entityCreateDto);

            employee.EmployeeID = Guid.NewGuid();

            return Task.FromResult(employee);
        }

        /// <summary>
        /// Insert các bảng phụ
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        protected override async Task InsertDetailTableAsync(EmployeeCreateDto employeeCreateDto, Guid employeeId)
        {
            var employeeRelationShips = _mapper.Map<IEnumerable<EmployeeRelationship>>(employeeCreateDto.EmployeeRelationships);

            foreach (var employeeRelationship in employeeRelationShips)
            {
                employeeRelationship.EmployeeRelationshipID = Guid.NewGuid();
                employeeRelationship.EmployeeID = employeeId;
            }

            await _employeeRelationshipRepository.InsertMultipleAsync(employeeRelationShips);
        }

        /// <summary>
        /// Validate nghiệp vụ cho Update
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <param name="entityUpdateDto">UpdateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override Task<Employee> MapUpdateDtoToEntityAsync(Guid entityId, EmployeeUpdateDto entityUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}

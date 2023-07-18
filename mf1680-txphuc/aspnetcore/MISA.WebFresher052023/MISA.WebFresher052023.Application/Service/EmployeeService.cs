using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class EmployeeService : IEmployeeService
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IEmployeeManager employeeManager,
            IDepartmentRepository departmentRepository,
            IPositionRepository positionRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeManager = employeeManager;
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeeDtos;
        }

        /// <summary>
        /// Tìm kiếm, filter và phân trang
        /// </summary>
        /// <param name="search">Search theo tên hoặc mã nhân viên</param>
        /// <param name="currentPage">trang hiện tại</param>
        /// <param name="pageSize">Số phần tử trên trang</param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<Pagination> FilterAsync(string? search, int? currentPage, int? pageSize)
        {
            if (string.IsNullOrEmpty(search))
            {
                search = "";
            }
            if (!currentPage.HasValue)
            {
                currentPage = 1;
            }
            if (!pageSize.HasValue)
            {
                pageSize = 10;
            }

            var pagedEmployees = await _employeeRepository.FilterAsync(search, currentPage.Value, pageSize.Value);

            pagedEmployees.Data = _mapper.Map<IEnumerable<EmployeeDto>>(pagedEmployees.Data);

            return pagedEmployees;
        }

        /// <summary>
        /// Lấy nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<EmployeeDto> GetByIdAsync(Guid employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<string?> FindNewEmployeeCodeAsync()
        {
            var newEmployeeCode = await _employeeRepository.FindNewEmployeeCodeAsync();

            return newEmployeeCode;
        }

        /// <summary>
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employeeCreateDto">Thông tin nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<int> InsertAsync(EmployeeCreateDto employeeCreateDto)
        {
            // Check trùng mã nhân viên
            await _employeeManager.CheckExistEmployeeCode(employeeCreateDto.EmployeeCode);

            // Check departmentId và positionId có tồn tại hay không
            await _employeeManager.CheckValidConstraint(employeeCreateDto.DepartmentId, employeeCreateDto.PositionId);

            var employee = _mapper.Map<Employee>(employeeCreateDto);

            // Set Id, ngày tạo và ngày sửa đổi bản ghi
            employee.EmployeeId = Guid.NewGuid();
            employee.CreatedDate = DateTime.Now;
            employee.CreatedBy = "txphuc";
            employee.ModifiedDate = DateTime.Now;
            employee.ModifiedBy = "txphuc";

            var result = await _employeeRepository.InsertAsync(employee);

            return result;
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employeeUpdateDto">Thông tin nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<int> UpdateAsync(Guid employeeId, EmployeeUpdateDto employeeUpdateDto)
        {
            // Check nhân viên có tồn tại hay không
            var oldEmployee = await _employeeRepository.GetByIdAsync(employeeId);

            // Check departmentId và positionId có tồn tại hay không
            await _employeeManager.CheckValidConstraint(employeeUpdateDto.DepartmentId, employeeUpdateDto.PositionId);

            // Check trùng mã nhân viên
            await _employeeManager.CheckExistEmployeeCode(employeeUpdateDto.EmployeeCode, oldEmployee.EmployeeCode);

            var newEmployee = _mapper.Map(employeeUpdateDto, oldEmployee);

            // Set lại ngày sửa đổi bản ghi
            newEmployee.ModifiedDate = DateTime.Now;
            newEmployee.ModifiedBy = "txphuc";

            var result = await _employeeRepository.UpdateAsync(newEmployee);

            return result;
        }

        /// <summary>
        /// Xoá nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<int> DeleteByIdAsync(Guid employeeId)
        {
            // Check nhân viên có tồn tại hay không
            var existEmployee = await _employeeRepository.GetByIdAsync(employeeId);

            var reruslt = await _employeeRepository.DeleteByIdAsync(existEmployee);

            return reruslt;
        }

        /// <summary>
        /// Xoá nhiều nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách Id của các nhân viên cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (16/07/2023)
        public async Task<int> DeleteAsync(IEnumerable<Guid> employeeIds)
        {
            List<Employee> employees = new();

            foreach (var employeeId in employeeIds)
            {
                // Check nhân viên có tồn tại hay không
                var existEmployee = await _employeeRepository.GetByIdAsync(employeeId);

                employees.Add(existEmployee);
            }

            var result = await _employeeRepository.DeleteAsync(employees);

            return result;
        }
        #endregion
    }
}

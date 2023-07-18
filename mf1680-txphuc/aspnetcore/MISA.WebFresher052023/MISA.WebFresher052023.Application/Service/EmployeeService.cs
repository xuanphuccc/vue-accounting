using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class EmployeeService : BaseCodeService<Employee,EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeManager _employeeManager;

        #endregion

        #region Constructor
        public EmployeeService(
            IEmployeeRepository employeeRepository, 
            IEmployeeManager employeeManager, 
            IMapper mapper) : base(employeeRepository, mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeManager = employeeManager;
        }
        #endregion

        #region Methods
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


        protected override async Task<Employee> MapCreateDtoToEntityAsync(EmployeeCreateDto employeeCreateDto)
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

            return employee;
        }

        protected override async Task<Employee> MapUpdateDtoToEntityAsync(Guid employeeId, EmployeeUpdateDto employeeUpdateDto)
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

            return newEmployee;
        }
        #endregion
    }
}

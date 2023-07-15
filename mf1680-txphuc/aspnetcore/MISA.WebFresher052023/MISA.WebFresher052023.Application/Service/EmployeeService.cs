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
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeManager employeeManager, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeManager = employeeManager;
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
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task InsertAsync(EmployeeCreateDto employeeCreateDto)
        {
            // Check trùng mã nhân viên
            await _employeeManager.CheckExistEmployeeCode(employeeCreateDto.EmployeeCode);

            var employee = _mapper.Map<Employee>(employeeCreateDto);

            // Set ngày tạo và ngày sửa đổi bản ghi
            employee.CreatedDate = DateTime.Now;
            employee.ModifiedDate = DateTime.Now;

            await _employeeRepository.InsertAsync(employee);
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task UpdateAsync(Guid employeeId, EmployeeUpdateDto employeeUpdateDto)
        {
            // Check nhân viên có tồn tại hay không
            var oldEmployee = await _employeeRepository.GetByIdAsync(employeeId);

            // Check trùng mã nhân viên
            await _employeeManager.CheckExistEmployeeCode(employeeUpdateDto.EmployeeCode, oldEmployee.EmployeeCode);

            var newEmployee = _mapper.Map(employeeUpdateDto, oldEmployee);

            // Set lại ngày sửa đổi bản ghi
            newEmployee.ModifiedDate = DateTime.Now;

            await _employeeRepository.UpdateAsync(newEmployee);
        }

        /// <summary>
        /// Xoá nhân viên   
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task DeleteAsync(Guid employeeId)
        {
            var existEmployee = await _employeeRepository.FindByIdAsync(employeeId);

            if (existEmployee == null)
            {
                throw new NotFoundException("Nhân viên không tồn tại");
            }

            await _employeeRepository.DeleteAsync(existEmployee);
        }
        #endregion
    }
}

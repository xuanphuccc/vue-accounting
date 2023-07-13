using AutoMapper;
using MISA.WebFresher052023.Demo.Dtos;
using MISA.WebFresher052023.Demo.Entities;
using MISA.WebFresher052023.Demo.Repositories;

namespace MISA.WebFresher052023.Demo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get toàn bộ nhân viên
        /// </summary>
        /// <returns>Trả về danh sách nhân viên</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _employeeRepository.GetAll();

            return employees;
        }

        /// <summary>
        /// Get một nhân viên thông qua Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Trả về một nhân viên thoả mãn</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<Employee> GetById(Guid employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId);

            return employee;
        }

        /// <summary>
        /// Tạo nhân viên
        /// </summary>
        /// <param name="employee">Data của nhân viên cần tạo</param>
        /// <returns>Số bản ghi tạo thành công</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<int> Create(EmployeeRequestDto employeeDto)
        {
            var newEmployee = _mapper.Map<Employee>(employeeDto);

            // Set ngày tạo và ngày sửa đổi bản ghi
            newEmployee.CreatedDate = DateTime.Now;
            newEmployee.ModifiedDate = DateTime.Now;

            var result = await _employeeRepository.Create(newEmployee);

            return result;
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee">Data của nhân viên cần sửa</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<int> Update(Guid employeeId, EmployeeRequestDto employee)
        {
            var oldEmployee = await _employeeRepository.GetById(employeeId);

            var newEmployee = _mapper.Map(employee, oldEmployee);

            // Set lại ngày sửa đổi bản ghi
            newEmployee.ModifiedDate = DateTime.Now;

            var result = await _employeeRepository.Update(employeeId, newEmployee);

            return result;
        }

        /// <summary>
        /// Xoá một nhân viên thông qua Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (13/07/2023)
        public async Task<int> DeleteById(Guid employeeId)
        {
            var result = await _employeeRepository.DeleteById(employeeId);

            return result;
        }

        /// <summary>
        /// Xoá nhiều nhân viên nhân viên thông qua mảng các Id
        /// </summary>
        /// <param name="employeeIds">Mảng Id của nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (13/07/2023)
        public async Task<int> Delete(Guid[] employeeIds)
        {
            return 0;
        }
    }
}

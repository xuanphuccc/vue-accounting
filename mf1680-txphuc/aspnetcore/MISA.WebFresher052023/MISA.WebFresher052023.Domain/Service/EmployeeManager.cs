using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Check trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần check</param>
        /// <param name="oldEmployeeCode">Mã nhân viên cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task CheckExistEmployeeCode(string employeeCode, string? oldEmployeeCode = null)
        {
            var existEmployee = await _employeeRepository.FindByCodeAsync(employeeCode);

            if (existEmployee != null && existEmployee.EmployeeCode != oldEmployeeCode)
            {
                throw new ConflictException($"Mã nhân viên '{employeeCode}' đã tồn tại");
            }
        }
        #endregion
    }
}

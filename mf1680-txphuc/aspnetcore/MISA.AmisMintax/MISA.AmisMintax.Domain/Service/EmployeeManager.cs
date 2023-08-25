using MISA.AmisMintax.Domain.Resources.Common;
using MISA.AmisMintax.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Check trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần check</param>
        /// <param name="oldEmployeeCode">Mã nhân viên cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (25/08/2023)
        public async Task CheckExistEmployeeCode(string employeeCode, string? oldEmployeeCode = null)
        {
            var existEmployee = await _employeeRepository.FindByCodeAsync(employeeCode);

            if (existEmployee != null && existEmployee.EmployeeCode != oldEmployeeCode)
            {
                var errorMessage = string.Format(ErrorMessage.ConflictCode, CommonResource.Employee, employeeCode);

                throw new ConflictException(errorMessage, ErrorCode.ConflictCode);
            }
        }
    }
}

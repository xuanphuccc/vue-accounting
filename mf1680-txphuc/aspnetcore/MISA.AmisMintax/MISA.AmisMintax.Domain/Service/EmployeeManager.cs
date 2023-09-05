using MISA.AmisMintax.Domain.Resources.Common;
using MISA.AmisMintax.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MISA.AmisMintax.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructors
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
        /// CreatedBy: txphuc (25/08/2023)
        public async Task CheckExistEmployeeCode(string employeeCode, string? oldEmployeeCode = null)
        {
            var existEmployee = await _employeeRepository.FindByCodeAsync(employeeCode);

            if (existEmployee != null && existEmployee.EmployeeCode != oldEmployeeCode)
            {
                var errorMessage = string.Format(
                    ErrorMessage.ConflictEmployee,
                    CommonResource.EmployeeCode,
                    employeeCode,
                    $"{existEmployee.EmployeeCode}-{existEmployee.FullName}");

                throw new ConflictException(errorMessage, ErrorCode.ConflictCode);
            }
        }

        /// <summary>
        /// Check trùng mã số thuế
        /// </summary>
        /// <param name="taxCode">Mã số thuế cần check</param>
        /// <param name="oldTaxCode">Mã số thuế cũ (trong trường hợp cập nhật)</param>
        /// CreatedBy: txphuc (02/09/2023)
        public async Task CheckExistTaxCode(string? taxCode, string? oldTaxCode = null)
        {
            if (!string.IsNullOrEmpty(taxCode))
            {
                var existEmployee = await _employeeRepository.FindByTaxCodeAsync(taxCode);

                if (existEmployee != null && existEmployee.TaxCode != oldTaxCode)
                {
                    var errorMessage = string.Format(
                            ErrorMessage.ConflictEmployee,
                            CommonResource.TaxCode,
                            taxCode,
                            $"{existEmployee.EmployeeCode}-{existEmployee.FullName}");

                    throw new ConflictException(errorMessage, ErrorCode.ConflictCode);
                }
            }
        }

        /// <summary>
        /// Check trùng số CMND/CCCD/Hộ chiếu
        /// </summary>
        /// <param name="identifyNumber">Số CMND/CCCD/Hộ chiếu cần check</param>
        /// <param name="oldIdentifyNumber">Số CMND/CCCD/Hộ chiếu cũ (trong trường hợp cập nhật)</param>
        /// CreatedBy: txphuc (02/09/2023)
        public async Task CheckExistIdentifyNumber(string? identifyNumber, string? oldIdentifyNumber = null)
        {
            if (!string.IsNullOrEmpty(identifyNumber))
            {
                var existEmployee = await _employeeRepository.FindByIdentifyNumberAsync(identifyNumber);

                if (existEmployee != null && existEmployee.IdentifyNumber != oldIdentifyNumber)
                {
                    var errorMessage = string.Format(
                            ErrorMessage.ConflictEmployee,
                            CommonResource.IdentifyType,
                            identifyNumber,
                            $"{existEmployee.EmployeeCode}-{existEmployee.FullName}");

                    throw new ConflictException(errorMessage, ErrorCode.ConflictCode);
                }
            }
        } 
        #endregion
    }
}

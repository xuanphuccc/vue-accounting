using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public interface IEmployeeManager
    {
        /// <summary>
        /// Check trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần check</param>
        /// <param name="oldEmployeeCode">Mã nhân viên cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (25/08/2023)
        Task CheckExistEmployeeCode(string employeeCode, string? oldEmployeeCode = null);

        /// <summary>
        /// Check trùng mã số thuế
        /// </summary>
        /// <param name="taxCode">Mã số thuế cần check</param>
        /// <param name="oldTaxCode">Mã số thuế cũ (trong trường hợp cập nhật)</param>
        /// CreatedBy: txphuc (02/09/2023)
        Task CheckExistTaxCode(string? taxCode, string? oldTaxCode = null);

        /// <summary>
        /// Check trùng số CMND/CCCD/Hộ chiếu
        /// </summary>
        /// <param name="identifyNumber">Số CMND/CCCD/Hộ chiếu cần check</param>
        /// <param name="oldIdentifyNumber">Số CMND/CCCD/Hộ chiếu cũ (trong trường hợp cập nhật)</param>
        /// CreatedBy: txphuc (02/09/2023)
        Task CheckExistIdentifyNumber(string? identifyNumber, string? oldIdentifyNumber = null);
    }
}

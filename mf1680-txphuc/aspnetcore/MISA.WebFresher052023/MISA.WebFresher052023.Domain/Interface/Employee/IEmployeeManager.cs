using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IEmployeeManager
    {
        /// <summary>
        /// Check trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần check</param>
        /// <param name="oldEmployeeCode">Mã nhân viên cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task CheckExistEmployeeCode(string employeeCode, string? oldEmployeeCode = null);

        /// <summary>
        /// Check mã nhân viên tối đa có thể nhập
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần check</param>
        /// CreatedBy: txphuc (08/08/2023)
        Task CheckMaxEmployeeCode(string employeeCode);

        /// <summary>
        /// Check các khoá ngoại có tồn tại hay không
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <param name="positionId">Id của vị trí</param>
        /// CreatedBy: txphuc (17/07/2023)
        Task CheckValidConstraint(Guid departmentId, Guid? positionId);
    }
}

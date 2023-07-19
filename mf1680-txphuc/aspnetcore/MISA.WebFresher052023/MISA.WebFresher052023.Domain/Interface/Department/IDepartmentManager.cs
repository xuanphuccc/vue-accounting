using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IDepartmentManager
    {
        /// <summary>
        /// Check trùng mã đơn vị
        /// </summary>
        /// <param name="departmentCode">Mã đơn vị</param>
        /// <param name="oldDepartmentCode">Mã đơn vị cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (15/07/2023)
        Task CheckExistDepartmentCode(string departmentCode, string? oldDepartmentCode = null);
    }
}

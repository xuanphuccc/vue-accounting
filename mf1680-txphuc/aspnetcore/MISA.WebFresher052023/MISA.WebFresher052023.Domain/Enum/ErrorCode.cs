using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public enum ErrorCode
    {
        /// <summary>
        /// Mã lỗi nhập liệu
        /// </summary>
        /// CreatedBy: txphuc (17/07/2023)
        BadRequest = 1000,

        /// <summary>
        /// Mã lỗi không tìm thấy tài nguyên
        /// </summary>
        /// CreatedBy: txphuc (17/07/2023)
        NotFound = 1001,

        /// <summary>
        /// Mã lỗi trùng mã
        /// </summary>
        /// CreatedBy: txphuc (17/07/2023)
        ConflictCode = 1002,

        /// <summary>
        /// Lỗi hệ thống
        /// </summary>
        /// CreatedBy: txphuc (17/07/2023)
        ServerError = 1003
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
     public enum EditMode
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// CreatedBy: txphuc (23/08/2023)
        Create = 0,

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// CreatedBy: txphuc (23/08/2023)
        Update = 1,

        /// <summary>
        /// Xoá
        /// </summary>
        /// CreatedBy: txphuc (23/08/2023)
        Delete = 2,
    }
}

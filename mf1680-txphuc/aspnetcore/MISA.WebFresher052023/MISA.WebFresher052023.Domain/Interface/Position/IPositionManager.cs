using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IPositionManager
    {
        /// <summary>
        /// Check trùng mã vị trí
        /// </summary>
        /// <param name="positionCode">Mã vị trí</param>
        /// <param name="oldPositionCode">Mã vị trí cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (15/07/2023)
        Task CheckExistPositionCode(string positionCode, string? oldPositionCode = null);

        /// <summary>
        /// Check mã vị trí tối đa có thể nhập
        /// </summary>
        /// <param name="positionCode">Mã vị trí cần check</param>
        /// CreatedBy: txphuc (08/08/2023)
        Task CheckMaxPositionCode(string positionCode);
    }
}

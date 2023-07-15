using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IPositionRepository
    {
        /// <summary>
        /// Lấy danh sách toàn bộ vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<IEnumerable<Position>> GetAllAsync();

        /// <summary>
        /// Lấy thông tin một vị trí
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Thông tin vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<Position> GetByIdAsync(Guid positionId);

        /// <summary>
        /// Thêm mới một vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<int> InsertAsync(Position position);

        /// <summary>
        /// Cập nhật một vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<int> UpdateAsync(Position position);

        /// <summary>
        /// Xoá một vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<int> DeleteAsync(Position position);
    }
}

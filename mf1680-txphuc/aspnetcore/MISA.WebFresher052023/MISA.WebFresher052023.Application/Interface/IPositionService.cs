using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public interface IPositionService
    {
        /// <summary>
        /// Lấy danh sách toàn bộ vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<IEnumerable<PositionDto>> GetAllAsync();

        /// <summary>
        /// Lấy thông tin một vị trí
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Thông tin vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<PositionDto> GetByIdAsync(Guid positionId);

        /// <summary>
        /// Thêm mới một vị trí
        /// </summary>
        /// <param name="positionCreateDto">Thông tin vị trí</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<int> InsertAsync(PositionCreateDto positionCreateDto);

        /// <summary>
        /// Cập nhật một vị trí
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <param name="positionUpdateDto">Thông tin vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<int> UpdateAsync(Guid positionId, PositionUpdateDto positionUpdateDto);

        /// <summary>
        /// Xoá một vị trí
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<int> DeleteAsync(Guid positionId);
    }
}

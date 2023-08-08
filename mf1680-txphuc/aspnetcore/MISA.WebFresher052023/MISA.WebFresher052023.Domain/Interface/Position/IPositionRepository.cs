using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IPositionRepository : IBaseCodeRepository<Position, Position>
    {
        /// <summary>
        /// Lấy số bản ghi phụ thuộc vào bản ghi hiện tại
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Số bản ghi phụ thuộc</returns>
        Task<Position> CheckConstraintByIdAsync(Guid positionId);

        /// <summary>
        /// Lấy các bản ghi có phụ thuộc
        /// </summary>
        /// <param name="positionIds">Danh sách Id của vị trí</param>
        /// <returns>Các vị trí có phụ thuộc</returns>
        Task<IEnumerable<Position>> CheckListConstraintAsync(IEnumerable<Guid> positionIds);
    }
}

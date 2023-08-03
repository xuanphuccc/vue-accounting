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
        Task<int> CheckConstraintByIdAsync(Guid positionId);

        /// <summary>
        /// Lấy các bản ghi có phụ thuộc
        /// </summary>
        /// <param name="positionIds">Danh sách Id của vị trí</param>
        /// <returns>Mã của các đơn vị có phụ thuộc</returns>
        Task<IEnumerable<string>> CheckListConstraintAsync(IEnumerable<Guid> positionIds);
    }
}

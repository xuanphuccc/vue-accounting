using Dapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public class PositionRepository : BaseCodeRepository<Position, Position>, IPositionRepository
    {
        #region Constructor
        public PositionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy số bản ghi phụ thuộc vào bản ghi hiện tại
        /// </summary>
        /// <param name="positionId">Id của đơn vị</param>
        /// <returns>Số bản ghi phụ thuộc</returns>
        public async Task<Position?> CheckConstraintByIdAsync(Guid positionId)
        {
            var param = new DynamicParameters();
            param.Add($"@{TableId}", positionId);

            var sql = $"Proc_{TableName}_CheckConstraintById";

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<Position>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entity;
        }

        /// <summary>
        /// Lấy các bản ghi có phụ thuộc
        /// </summary>
        /// <param name="positionIds">Danh sách Id của vị trí</param>
        /// <returns>Các vị trí có phụ thuộc</returns>
        public async Task<IEnumerable<Position>> CheckListConstraintAsync(IEnumerable<Guid> positionIds)
        {
            var postionIdsString = string.Join(", ", positionIds.Select(positionId => $"'{positionId}'"));

            var param = new DynamicParameters();
            param.Add($"@{TableId}s", postionIdsString);

            var sql = $"Proc_{TableName}_CheckListConstraint";

            var positionCodes = await _unitOfWork.Connection.QueryAsync<Position>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return positionCodes;
        }
        #endregion
    }
}

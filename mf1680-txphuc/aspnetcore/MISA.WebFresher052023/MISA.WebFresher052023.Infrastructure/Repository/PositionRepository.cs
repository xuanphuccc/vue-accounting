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
    public class PositionRepository : IPositionRepository
    {
        #region Fields
        private readonly DbConnection _connection;
        #endregion

        #region Constructor
        public PositionRepository(DbConnection connection)
        {
            _connection = connection;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy danh sách toàn bộ vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            var sql = "Proc_Position_GetAll";

            var positions = await _connection.QueryAsync<Position>(sql, commandType: CommandType.StoredProcedure);

            return positions;
        }

        /// <summary>
        /// Lấy thông tin một vị trí theo Id
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Thông tin vị trí (trả về NotFoundException nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<Position> GetByIdAsync(Guid positionId)
        {
            var sql = "Proc_Position_GetById";

            var parameters = new DynamicParameters();
            parameters.Add("@PositionId", positionId);

            var position = await _connection.QueryFirstOrDefaultAsync<Position>(sql, parameters, commandType: CommandType.StoredProcedure);

            if (position == null)
            {
                throw new NotFoundException("Vị trí không tồn tại");
            }

            return position;
        }

        /// <summary>
        /// Lấy thông tin một vị trí theo mã vị trí
        /// </summary>
        /// <param name="positionCode">Mã vị trí</param>
        /// <returns>Thông tin vị trí (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<Position> FindByCodeAsync(string positionCode)
        {
            var sql = "Proc_Position_GetByCode";

            var parameters = new DynamicParameters();
            parameters.Add("@PositionCode", positionCode);

            var position = await _connection.QueryFirstOrDefaultAsync<Position>(sql, parameters, commandType: CommandType.StoredProcedure);

            return position;
        }

        /// <summary>
        /// Thêm mới một vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> InsertAsync(Position position)
        {
            var sql = "Proc_Position_Create";

            var parameters = new DynamicParameters();
            parameters.Add("@PositionId", position.PositionId);
            parameters.Add("@PositionCode", position.PositionCode);
            parameters.Add("@PositionName", position.PositionName);
            parameters.Add("@Description", position.Description);
            parameters.Add("@CreatedDate", position.CreatedDate);
            parameters.Add("@CreatedBy", position.CreatedBy);
            parameters.Add("@ModifiedDate", position.ModifiedDate);
            parameters.Add("@ModifiedBy", position.ModifiedBy);

            var result = await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Cập nhật một vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> UpdateAsync(Position position)
        {
            var sql = "Proc_Position_Update";

            var parameters = new DynamicParameters();
            parameters.Add("@PositionId", position.PositionId);
            parameters.Add("@PositionCode", position.PositionCode);
            parameters.Add("@PositionName", position.PositionName);
            parameters.Add("@Description", position.Description);
            parameters.Add("@ModifiedDate", position.ModifiedDate);
            parameters.Add("@ModifiedBy", position.ModifiedBy);

            var result = await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Xoá một vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> DeleteAsync(Position position)
        {
            var sql = "Proc_Position_DeleteById";

            var parameters = new DynamicParameters();
            parameters.Add("@PositionId", position.PositionId);

            var result = await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
        #endregion
    }
}

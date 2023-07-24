using Dapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public abstract class BaseRepository<TEntity, TModel> : BaseReadOnlyRepository<TEntity, TModel>, IBaseRepository<TEntity, TModel> where TEntity : IHasKey
    {
        #region Constructors
        protected BaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="entity">Data của đối tượng</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> InsertAsync(TEntity entity)
        {
            var param = MapEntityToParams(entity);

            var sql = $"Proc_{TableName}_Create";

            var result = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entity">Data của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> UpdateAsync(TEntity entity)
        {
            var param = MapEntityToParams(entity);

            var sql = $"Proc_{TableName}_UpdateById";

            var result = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Xoá đối tượng theo Id
        /// </summary>
        /// <param name="entity">Thông tin đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> DeleteByIdAsync(TEntity entity)
        {
            var param = new DynamicParameters();

            //if (entity is IHasKey entityHasKey)
            //{
            //    param.Add($"@{TableId}", entityHasKey.GetKey());
            //}

            param.Add($"@{TableId}", entity.GetKey());

            var sql = $"Proc_{TableName}_DeleteById";

            var result = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Xoá nhiều đối tượng
        /// </summary>
        /// <param name="entities">Danh sách đối tượng cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> DeleteAsync(IEnumerable<TEntity> entities)
        {
            var entityIdsString = string.Join(", ", entities.Select(entity => $"'{entity.GetKey()}'"));

            var param = new DynamicParameters();
            param.Add($"@{TableId}s", entityIdsString);

            var sql = $"Proc_{TableName}_Delete";

            var result = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Map các thuộc tính của đối tượng sang DynamicParameters
        /// để truyền vào Procedure
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>DynamicParameters</returns>
        /// CreatedBy: txphuc (18/07/2023)
        private DynamicParameters MapEntityToParams(TEntity entity)
        {
            var param = new DynamicParameters();

            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                param.Add($"@{property.Name}", value);
            }

            return param;
        }
        #endregion
    }
}

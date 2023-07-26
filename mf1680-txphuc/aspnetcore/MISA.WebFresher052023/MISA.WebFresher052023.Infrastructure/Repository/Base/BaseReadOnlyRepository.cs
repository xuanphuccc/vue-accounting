using Dapper;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public abstract class BaseReadOnlyRepository<TEntity, TModel> : IBaseReadOnlyRepository<TEntity, TModel>
    {
        #region Fields & Properties
        protected readonly IUnitOfWork _unitOfWork;
        public virtual string TableName { get; protected set; } = typeof(TEntity).Name;
        public virtual string TableId { get; protected set; } = $"{typeof(TEntity).Name}Id";
        #endregion

        #region Constructors
        protected BaseReadOnlyRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var sql = $"Proc_{TableName}_GetAll";

            var entities = await _unitOfWork.Connection.QueryAsync<TModel>(sql, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entities;
        }

        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Đối tượng (trả về NotFoundException nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<TEntity> GetByIdAsync(Guid entityId)
        {
            var entity = await FindByIdAsync(entityId);

            if (entity == null)
            {
                throw new NotFoundException($"{ErrorMessage.NotFound} '{entityId}'", ErrorCode.NotFound);
            }

            return entity;
        }

        /// <summary>
        /// Lấy danh sách đối tượng theo Id
        /// </summary>
        /// <param name="entityIds">Danh sách Id</param>
        /// <returns>Danh sách đối tượng thoả mãn</returns>
        /// CreatedBy: txphuc (24/07/2023)
        public async Task<IEnumerable<TEntity>> GetListByIdsAsync(IEnumerable<Guid> entityIds)
        {
            var entityIdsString = string.Join(", ", entityIds.Select(entityId => $"'{entityId}'"));

            var param = new DynamicParameters();
            param.Add($"@{TableId}s", entityIdsString);

            var sql = $"Proc_{TableName}_GetListByIds";

            var entities = await _unitOfWork.Connection.QueryAsync<TEntity>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entities;
        }

        /// <summary>
        /// Lấy danh sách bản ghi đầy đủ thông tin đơn vị và vị trí theo Id
        /// </summary>
        /// <param name="entityIds">Danh sách Id</param>
        /// <returns>Danh sách bản ghi thoả mãn</returns>
        /// CreatedBy: txphuc (26/07/2023)
        public async Task<IEnumerable<TModel>> GetListInfoByIdsAsync(IEnumerable<Guid> entityIds)
        {
            var entityIdsString = string.Join(", ", entityIds.Select(entityId => $"'{entityId}'"));

            var param = new DynamicParameters();
            param.Add($"@{TableId}s", entityIdsString);

            var sql = $"Proc_{TableName}_GetListInfoByIds";

            var entities = await _unitOfWork.Connection.QueryAsync<TModel>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entities;
        }

        /// <summary>
        /// Tìm đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Đối tượng (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<TEntity?> FindByIdAsync(Guid entityId)
        {
            var param = new DynamicParameters();
            param.Add($"@{TableId}", entityId);

            var sql = $"Proc_{TableName}_GetById";

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entity;
        }
        #endregion
    }
}

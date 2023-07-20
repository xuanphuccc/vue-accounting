﻿using Dapper;
using MISA.WebFresher052023.Domain;
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

        #region Constructor
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
                throw new NotFoundException($"Không tìm thấy '{entityId}'", (int)ErrorCodes.NotFound);
            }

            return entity;
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

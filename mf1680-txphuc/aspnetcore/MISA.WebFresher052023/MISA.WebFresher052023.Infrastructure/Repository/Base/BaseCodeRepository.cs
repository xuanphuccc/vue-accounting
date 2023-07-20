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
    public abstract class BaseCodeRepository<TEntity, TModel> : BaseRepository<TEntity, TModel>, IBaseCodeRepository<TEntity, TModel> where TEntity : IHasKey
    {
        #region Constructors
        public BaseCodeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Lấy đối tượng theo mã đối tượng
        /// </summary>
        /// <param name="entityCode">Mã đối tượng</param>
        /// <returns>Nhân viên (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<TEntity> FindByCodeAsync(string entityCode)
        {
            var param = new DynamicParameters();
            param.Add($"@{TableName}Code", entityCode);

            var sql = $"Proc_{TableName}_GetByCode";

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entity;
        }

        /// <summary>
        /// Lấy mã đối tượng mới
        /// </summary>
        /// <returns>Mã đối tượng mới nhất</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<string?> FindNewCodeAsync()
        {
            var sql = $"Proc_{TableName}_GetNewCode";

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<string>(sql, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entity;
        } 
        #endregion
    }
}

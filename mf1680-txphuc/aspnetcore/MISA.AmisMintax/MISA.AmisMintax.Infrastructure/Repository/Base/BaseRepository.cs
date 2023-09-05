using Dapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static OfficeOpenXml.ExcelErrorValue;

namespace MISA.AmisMintax.Infrastructure
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
        public async Task<Guid> InsertAsync(TEntity entity)
        {
            var parameters = new DynamicParameters();

            string insertQuery = InsertQueryBuilder(entity, parameters);

            await _unitOfWork.Connection.ExecuteAsync(insertQuery, parameters, transaction: _unitOfWork.Transaction);

            return entity.GetKey();
        }

        /// <summary>
        /// Thêm nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách đối tượng</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (22/08/2023)
        public async Task<int> InsertMultipleAsync(IEnumerable<TEntity> entities)
        {
            var parameters = new DynamicParameters();

            List<string> insertQueries = new();

            var index = 0;
            foreach (var entity in entities)
            {
                string insertQuery = InsertQueryBuilder(entity, parameters, index);

                insertQueries.Add(insertQuery);

                index++;
            }

            var insertSqlString = string.Join("; ", insertQueries);

            var result = await _unitOfWork.Connection.ExecuteAsync(insertSqlString, parameters, transaction: _unitOfWork.Transaction);

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
            var parameters = new DynamicParameters();

            string updateQuery = UpdateQueryBuilder(entity, parameters);

            var result = await _unitOfWork.Connection.ExecuteAsync(updateQuery, parameters, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Cập nhật nhều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> UpdateMultipleAsync(IEnumerable<TEntity> entities)
        {
            var parameters = new DynamicParameters();

            List<string> insertQueries = new();

            var index = 0;
            foreach (var entity in entities)
            {
                string insertQuery = UpdateQueryBuilder(entity, parameters, index);

                insertQueries.Add(insertQuery);

                index++;
            }

            var insertSqlString = string.Join("; ", insertQueries);

            var result = await _unitOfWork.Connection.ExecuteAsync(insertSqlString, parameters, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Xoá đối tượng theo Id
        /// </summary>
        /// <param name="entity">Thông tin đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> DeleteAsync(TEntity entity)
        {
            var param = new DynamicParameters();

            param.Add($"@{TableId}", entity.GetKey());

            var sql = $"Proc_{TableName}_DeleteById";

            var result = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Xoá nhiều đối tượng
        /// </summary>
        /// <param name="entityIds">Danh sách Id của đối tượng cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> DeleteMultipleAsync(IEnumerable<Guid> entityIds)
        {
            var entityIdsString = string.Join(", ", entityIds.Select(entity => $"'{entity}'"));

            if (String.IsNullOrEmpty(entityIdsString))
            {
                // Trường hợp không có Id nào
                entityIdsString = "''";
            }

            var param = new DynamicParameters();
            param.Add($"@{TableId}s", entityIdsString);

            var sql = $"Proc_{TableName}_Delete";

            var result = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Xử lý tạo câu truy vấn insert bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng cần insert</param>
        /// <param name="parameters">Các tham số</param>
        /// <param name="index">Vị trí của phần tử trong danh sách (trường hợp insert nhiều bản ghi)</param>
        /// <returns>Câu lệnh insert</returns>
        /// CreatedBy: txphuc (02/09/2023)
        private string InsertQueryBuilder(TEntity entity, DynamicParameters parameters, int? index = 0)
        {
            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            // Lấy tên các trường
            IEnumerable<string> columns = properties.Select(property => property.Name);
            string columnsString = string.Join(", ", columns);

            // Gán placeholder và gán giá trị cho paramerter
            IEnumerable<string> valuePlaceholders = properties.Select(property =>
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                var valuePlaceholder = $"@{propName}{index}";

                parameters.Add(valuePlaceholder, propValue);

                return valuePlaceholder;
            });

            var valuePlaceholdersString = string.Join(", ", valuePlaceholders);

            string insertQuery = $"INSERT INTO {TableName} ({columnsString}) VALUES ({valuePlaceholdersString})";

            return insertQuery;
        }

        /// <summary>
        /// Xử lý tạo câu truy vấn update bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng cần update</param>
        /// <param name="parameters">Các tham số</param>
        /// <param name="index">Vị trí của phần tử trong danh sách (trường hợp insert nhiều bản ghi)</param>
        /// <returns>Câu lệnh update</returns>
        /// CreatedBy: txphuc (02/09/2023)
        private string UpdateQueryBuilder(TEntity entity, DynamicParameters parameters, int? index = 0)
        {
            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            // Gán placeholder và gán giá trị cho paramerter
            // Không cập nhật trường (CreateDate và CreateBy)
            IEnumerable<string> valuePlaceholders =
            properties.Where(property => property.Name != "CreatedDate" && property.Name != "CreatedBy")
            .Select(property =>
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                var valuePlaceholder = $"@{propName}{index}";

                parameters.Add(valuePlaceholder, propValue);

                return $"{propName} = {valuePlaceholder}";
            });

            var valuePlaceholdersString = string.Join(", ", valuePlaceholders);

            string updateQuery = $"UPDATE {TableName} SET {valuePlaceholdersString} WHERE {TableName}ID = '{entity.GetKey()}'";

            return updateQuery;
        }
        #endregion
    }
}

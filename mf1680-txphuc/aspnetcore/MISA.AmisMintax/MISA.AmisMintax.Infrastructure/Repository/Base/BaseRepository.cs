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
    public abstract class BaseRepository<TEntity> : BaseReadOnlyRepository<TEntity>, IBaseRepository<TEntity> where TEntity : IHasKey
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

            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            // Lấy tên các cột
            IEnumerable<string> columns = properties.Select(property => property.Name);
            string columnsString = string.Join(", ", columns);

            // Gán placeholder và gán giá trị cho paramerter
            IEnumerable<string> valuePlaceholders = properties.Select(property =>
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                var valuePlaceholder = $"@{propName}";

                parameters.Add(valuePlaceholder, propValue);

                return valuePlaceholder;
            });

            var valuePlaceholdersString = string.Join(", ", valuePlaceholders);

            string insertQuery = $"INSERT INTO {TableName} ({columnsString}) VALUES ({valuePlaceholdersString})";

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

            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            List<string> insertQueries = new();

            // Lấy tên các cột
            IEnumerable<string> columns = properties.Select(property => property.Name);
            string columnsString = string.Join(", ", columns);

            var index = 0;
            foreach (var entity in entities)
            {
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

            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            // Gán placeholder và gán giá trị cho paramerter
            // Không cập nhật trường (CreateDate và CreateBy)
            IEnumerable<string> valuePlaceholders =
            properties.Where(property => property.Name != "CreatedDate" && property.Name != "CreatedBy")
            .Select(property =>
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                var valuePlaceholder = $"@{propName}";

                parameters.Add(valuePlaceholder, propValue);

                return $"{propName} = {valuePlaceholder}";
            });

            var valuePlaceholdersString = string.Join(", ", valuePlaceholders);

            string updateQuery = $"UPDATE {TableName} SET {valuePlaceholdersString} WHERE {TableName}ID = '{entity.GetKey()}'";

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

            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            List<string> insertQueries = new();

            var index = 0;
            foreach (var entity in entities)
            {
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

                string insertQuery = $"UPDATE {TableName} SET {valuePlaceholdersString} WHERE {TableName}ID = '{entity.GetKey()}'";

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
        /// Map các thuộc tính của đối tượng sang DynamicParameters
        /// để truyền vào Procedure
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>DynamicParameters</returns>
        /// CreatedBy: txphuc (18/07/2023)
        private DynamicParameters MapEntityToParams(TEntity entity)
        {
            var parameters = new DynamicParameters();

            var properties = typeof(TEntity).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                parameters.Add($"@{property.Name}", value);
            }

            return parameters;
        }
        #endregion
    }
}

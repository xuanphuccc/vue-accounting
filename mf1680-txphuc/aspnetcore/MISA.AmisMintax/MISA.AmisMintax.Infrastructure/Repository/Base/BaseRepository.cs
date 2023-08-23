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
        public async Task<int> InsertAsync(TEntity entity)
        {
            var param = MapEntityToParams(entity);

            var sql = $"Proc_{TableName}_Create";

            var result = await _unitOfWork.Connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Thêm nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách đối tượng</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (22/08/2023)
        public async Task<int> InsertMultipleAsync(IEnumerable<TEntity> entities)
        {
            List<string> queries = new();

            foreach (var entity in entities)
            {
                var sql = BuildInsertSql(entity);
                queries.Add(sql);
            }

            // Gộp các lệnh INSERT
            var queriesString = String.Join(" ", queries);

            var result = await _unitOfWork.Connection.ExecuteAsync(queriesString, transaction: _unitOfWork.Transaction);

            return result;
        }

        /// <summary>
        /// Tạo câu lệnh INSERT cho đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần insert</param>
        /// <returns>Chuỗi SQL</returns>
        /// CreatedBy: txphuc (22/08/2023)
        private string BuildInsertSql(TEntity entity)
        {
            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            string columns = string.Join(", ", properties.Select(p => p.Name));
            string values = string.Join(", ", properties.Select(p => GetSqlValue(p.GetValue(entity))));

            string insertSql = $"INSERT INTO {TableName} ({columns}) VALUES ({values})";

            return insertSql;
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
        /// Cập nhật nhều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public async Task<int> UpdateMultipleAsync(IEnumerable<TEntity> entities)
        {
            return 0;
        }

        /// <summary>
        /// Tạo câu lệnh INSERT cho đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần insert</param>
        /// <returns>Chuỗi SQL</returns>
        /// CreatedBy: txphuc (22/08/2023)
        private string BuildUpdateSql(TEntity entity)
        {
            PropertyInfo[] properties = typeof(TEntity).GetProperties();

            string columns = string.Join(", ", properties.Select(p => p.Name));
            string values = string.Join(", ", properties.Select(p => GetSqlValue(p.GetValue(entity))));

            string insertSql = $"UPDATE {TableName} e \r\nSET EmployeeID = '',\r\nWHERE EmployeeID = '';";
            return insertSql;
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

            if(String.IsNullOrEmpty(entityIdsString))
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

        /// <summary>
        /// Chuyển đổi dữ liệu phù hợp với lệnh SQL
        /// </summary>
        /// <param name="value">Giá trị cần chuyển</param>
        /// <returns>Chuỗi có định dạng phù hợp</returns>
        /// CreatedBy: txphuc (22/08/2023)
        private string GetSqlValue(object value)
        {
            if (value is null)
            {
                return "NULL";
            }
            else if (value is string || value is Guid)
            {
                return $"'{value}'";
            }
            else if (value is DateTime)
            {
                return $"'{((DateTime)value).ToString("yyyy-MM-dd")}'";
            }
            else if (value.GetType().IsEnum)
            {
                return ((int)value).ToString();
            }
            else
            {
                return value.ToString() ?? "NULL";
            }
        }


        //public async Task<int> InsertManyAsync(List<TEntity> entities)
        //{
        //    int rowsInserted = 0;

        //    var parameters = new DynamicParameters();
        //    var sb = new StringBuilder();
        //    sb.Append($"INSERT INTO {tableName} (");

        //    // Get the properties of the entity
        //    var properties = typeof(TEntity).GetProperties();

        //    // Add the property names to the SQL statement
        //    foreach (var property in properties)
        //    {
        //        var propertyName = $"m_{property.Name}";
        //        sb.Append($"{propertyName}, ");
        //    }

        //    sb.Append("m_CreatedDate, m_CreatedBy, m_ModifiedDate, m_ModifiedBy) VALUES ");

        //    // Add the parameter placeholders to the SQL statement
        //    for (int i = 0; i < entities.Count; i++)
        //    {
        //        sb.Append("(");

        //        foreach (var property in properties)
        //        {
        //            var propertyName = $"m_{property.Name}{i}";
        //            var propertyValue = property.GetValue(entities[i]);
        //            parameters.Add(propertyName, propertyValue);
        //            sb.Append($"@{propertyName}, ");
        //        }

        //        sb.Append($"@m_CreatedDate{i}, @m_CreatedBy{i}, @m_ModifiedDate{i}, @m_ModifiedBy{i}), ");

        //        parameters.Add($"m_{tableName}Id{i}", Guid.NewGuid());
        //        parameters.Add($"m_CreatedDate{i}", DateTime.Now);
        //        parameters.Add($"m_CreatedBy{i}", "dgbao");
        //        parameters.Add($"m_ModifiedDate{i}", DateTime.Now);
        //        parameters.Add($"m_ModifiedBy{i}", "dgbao");
        //    }

        //    sb.Remove(sb.Length - 2, 2);

        //    // Thực thi câu lệnh insert tổng hợp 
        //    rowsInserted = await _uow.Connection.ExecuteAsync(sb.ToString(), parameters,
        //        commandType: CommandType.Text, transaction: _uow.Transaction);

        //    return rowsInserted;
        //}
        #endregion
    }
}

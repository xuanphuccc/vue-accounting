using Dapper;
using MISA.AmisMintax.Domain;
using MISA.AmisMintax.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MISA.AmisMintax.Infrastructure
{
    public class EmployeeRelationshipRepository : BaseRepository<EmployeeRelationship, EmployeeRelationshipModel>, IEmployeeRelationshipRepository
    {
        #region Constructors
        public EmployeeRelationshipRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy danh sách người thân theo Id nhân viên
        /// </summary>
        /// <param name="employeeId">Id của nhân viên muốn lấy danh sách người thân</param>
        /// <returns>Danh sách người thân của nhân viên</returns>
        /// CreatedBy: txphuc (22/08/2023)
        public async Task<IEnumerable<EmployeeRelationshipModel>> GetListByEmployeeIdAsync(IEnumerable<Guid> employeeIds)
        {
            var entityIdsString = string.Join(", ", employeeIds.Select(entity => $"'{entity}'"));

            if (String.IsNullOrEmpty(entityIdsString))
            {
                // Trường hợp không có Id nào
                entityIdsString = "''";
            }

            var param = new DynamicParameters();
            param.Add($"@EmployeeIds", entityIdsString);

            var sql = $"Proc_{TableName}_GetListByEmployeeIds";

            var entities = await _unitOfWork.Connection.QueryAsync<EmployeeRelationshipModel>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entities;
        } 
        #endregion
    }
}

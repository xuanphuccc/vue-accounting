using MISA.WebFresher052023.Domain;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MISA.WebFresher052023.Infrastructure
{
    public class DepartmentRepository : BaseCodeRepository<Department, Department>, IDepartmentRepository
    {
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Lấy số bản ghi phụ thuộc vào bản ghi hiện tại
        /// </summary>
        /// <param name="department">đơn vị</param>
        /// <returns>Số bản ghi phụ thuộc</returns>
        public async Task<Department?> CheckConstraintByIdAsync(Guid departmentId)
        {
            var param = new DynamicParameters();
            param.Add($"@{TableId}", departmentId);

            var sql = $"Proc_{TableName}_CheckConstraintById";

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<Department>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entity;
        }

        /// <summary>
        /// Lấy các bản ghi có phụ thuộc
        /// </summary>
        /// <param name="departments">Danh sách đơn vị</param>
        /// <returns>Mã của các đơn vị có phụ thuộc</returns>
        public async Task<IEnumerable<string>> CheckListConstraintAsync(IEnumerable<Guid> departmentIds)
        {
            var departmentIdsString = string.Join(", ", departmentIds.Select(departmentId => $"'{departmentId}'"));

            var param = new DynamicParameters();
            param.Add($"@{TableId}s", departmentIdsString);

            var sql = $"Proc_{TableName}_CheckListConstraint";

            var departmentCodes = await _unitOfWork.Connection.QueryAsync<string>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return departmentCodes;
        }
    }
}

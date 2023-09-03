using Dapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace MISA.AmisMintax.Infrastructure
{
    public class EmployeeRepository : BaseCodeRepository<Employee, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Tìm kiếm, filter, sắp xếp, phân trang
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <returns>Thông tin phân trang</returns>
        /// CreatedBy: txphuc (20/08/2023)
        public async Task<Pagination> FilterAsync(EmployeeFilterModel employeeFilter)
        {
            var parameters = new DynamicParameters();

            // Map thuộc tính sang params
            var properties = typeof(EmployeeFilterModel).GetProperties();

            foreach (var property in properties)
            {
                if (property.Name != "TotalRecords")
                {
                    var value = property.GetValue(employeeFilter);
                    parameters.Add($"@{property.Name}", value);
                }
            }
            parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var sql = "Proc_Employee_FilterAndPaging";

            // Lấy data nhân viên
            var employeeModels = await _unitOfWork.Connection.QueryAsync<Employee>(sql, parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            // Lấy tổng số bản ghi
            var totalRecords = parameters.Get<int?>("@TotalRecords");

            return new Pagination()
            {
                Data = employeeModels,
                TotalRecords = totalRecords,
            };
        }

        /// <summary>
        /// Đếm số bản ghi đang được sử dụng
        /// </summary>
        /// <returns>Số bản ghi đang được sử dụng và tổng số bản ghi</returns>
        /// CreatedBy: txphuc (25/08/2023)
        public async Task<UsageCount> GetUsageCountAsync()
        {
            var parameters = new DynamicParameters();

            parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@UsedRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var sql = "Proc_Employee_GetUsageCount";

            await _unitOfWork.Connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            var totalRecords = parameters.Get<int?>("@TotalRecords");
            var usedRecords = parameters.Get<int?>("@UsedRecords");

            return new UsageCount()
            {
                TotalRecords = totalRecords,
                UsedRecords = usedRecords
            };
        }

        /// <summary>
        /// Tìm thông tin nhân viên theo mã số thuế
        /// </summary>
        /// <param name="taxCode">Mã số thuế</param>
        /// <returns>Bản ghi thoả mãn</returns>
        /// CreatedBy: txphuc (02/09/2023)
        public async Task<Employee> FindByTaxCodeAsync(string taxCode)
        {

            var param = new DynamicParameters();
            param.Add($"@TaxCode", taxCode);

            var sql = $"Proc_{TableName}_GetByTaxCode";

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<Employee>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entity;
        }

        /// <summary>
        /// Tìm thông tin nhân viên theo số CMND/CCCD/Hộ chiếu
        /// </summary>
        /// <param name="identifyNumber">Số CMND/CCCD/Hộ chiếu</param>
        /// <returns>Bản ghi thoả mãn</returns>
        /// CreatedBy: txphuc (02/09/2023)
        public async Task<Employee> FindByIdentifyNumberAsync(string identifyNumber)
        {
            var param = new DynamicParameters();
            param.Add($"@IdentifyNumber", identifyNumber);

            var sql = $"Proc_{TableName}_GetByIdentifyNumber";

            var entity = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<Employee>(sql, param, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            return entity;
        }
    }
}

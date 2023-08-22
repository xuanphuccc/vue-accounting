using Dapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Infrastructure
{
    public class EmployeeRepository : BaseCodeRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Tìm kiếm, filter, sắp xếp, phân trang
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <returns>Thông tin phân trang</returns>
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
    }
}

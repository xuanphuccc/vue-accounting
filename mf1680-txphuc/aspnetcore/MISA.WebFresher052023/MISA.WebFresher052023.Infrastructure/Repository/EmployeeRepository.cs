using Dapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public class EmployeeRepository : BaseCodeRepository<Employee, EmployeeModel>, IEmployeeRepository
    {
        #region Constructors
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tìm kiếm, filter và phân trang
        /// </summary>
        /// <param name="employeeFilterModel">Tham số filter</param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<Pagination> FilterAsync(EmployeeFilterModel employeeFilterModel)
        {
            var parameters = new DynamicParameters();

            // Map thuộc tính sang params
            var properties = typeof(EmployeeFilterModel).GetProperties();

            foreach (var property in properties)
            {
                if(property.Name != "TotalRecords")
                {
                    var value = property.GetValue(employeeFilterModel);
                    parameters.Add($"@{property.Name}", value);
                }
            }
            parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var sql = "Proc_Employee_FilterTest";

            // Lấy data nhân viên
            var employeeModels = await _unitOfWork.Connection.QueryAsync<EmployeeModel>(sql, parameters, commandType: CommandType.StoredProcedure, transaction: _unitOfWork.Transaction);

            // Lấy tổng số bản ghi
            var totalRecords = parameters.Get<int?>("@TotalRecords");

            return new Pagination()
            {
                Data = employeeModels,
                TotalRecords = totalRecords,
            };
        }
        #endregion
    }
}

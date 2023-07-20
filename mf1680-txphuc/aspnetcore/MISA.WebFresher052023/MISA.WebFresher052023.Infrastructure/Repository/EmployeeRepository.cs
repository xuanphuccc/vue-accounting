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
        /// <param name="search">Search theo tên hoặc mã nhân viên</param>
        /// <param name="currentPage">trang hiện tại</param>
        /// <param name="pageSize">Số phần tử trên trang</param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<Pagination> FilterAsync(string search, int currentPage, int pageSize)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Search", search);
            parameters.Add("@Page", currentPage);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var sql = "Proc_Employee_FilterAndPaging";

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

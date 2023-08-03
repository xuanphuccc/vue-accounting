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
        public async Task<Pagination> FilterAsync(
            int currentPage,
            int pageSize,
            string? search,
            string? sortColumn,
            string? sortOrder,
            string? employeeCode,
            string? employeeCodeFilterBy,
            string? fullName,
            string? fullNameFilterBy,
            Gender? gender,
            string? genderFilterBy,
            DateTime? dateOfBirth,
            string? dateOfBirthFilterBy,
            string? identityNumber,
            string? identityNumberFilterBy,
            string? positionName,
            string? positionNameFilterBy,
            string? departmentName,
            string? departmentNameFiterBy,
            string? bankAccount,
            string? bankAccountFilterBy,
            string? bankName,
            string? bankNameFilterBy,
            string? bankBranch,
            string? bankBranchFilterBy)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Page", currentPage);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Search", search);
            parameters.Add("@SortColumn", sortColumn);
            parameters.Add("@SortOrder", sortOrder);
            parameters.Add("@EmployeeCode", employeeCode);
            parameters.Add("@EmployeeCodeFilterBy", employeeCodeFilterBy);
            parameters.Add("@FullName", fullName);
            parameters.Add("@FullNameFilterBy", fullNameFilterBy);
            parameters.Add("@Gender", gender);
            parameters.Add("@GenderFilterBy", genderFilterBy);
            parameters.Add("@DateOfBirth", dateOfBirth);
            parameters.Add("@DateOfBirthFilterBy", dateOfBirthFilterBy);
            parameters.Add("@IdentityNumber", identityNumber);
            parameters.Add("@IdentityNumberFilterBy", identityNumberFilterBy);
            parameters.Add("@PositionName", positionName);
            parameters.Add("@PositionNameFilterBy", positionNameFilterBy);
            parameters.Add("@DepartmentName", departmentName);
            parameters.Add("@DepartmentNameFilterBy", departmentNameFiterBy);
            parameters.Add("@BankAccount", bankAccount);
            parameters.Add("@BankAccountFilterBy", bankAccountFilterBy);
            parameters.Add("@BankName", bankName);
            parameters.Add("@BankNameFilterBy", bankNameFilterBy);
            parameters.Add("@BankBranch", bankBranch);
            parameters.Add("@BankBranchFilterBy", bankBranchFilterBy);

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

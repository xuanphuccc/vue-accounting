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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbConnection _connection;

        public EmployeeRepository(DbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var sql = "Proc_Employee_GetAll";

            var employees = await _connection.QueryAsync<Employee>(sql, commandType: CommandType.StoredProcedure);

            return employees;
        }

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
            var employeeModels = await _connection.QueryAsync<EmployeeModel>(sql, parameters, commandType: CommandType.StoredProcedure);

            // Lấy tổng số bản ghi
            var totalRecords = parameters.Get<int?>("@TotalRecords");

            return new Pagination()
            {
                Data = employeeModels,
                TotalRecords = totalRecords,
            };
        }

        /// <summary>
        /// Lấy nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên (trả về NotFoundException nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<Employee> GetByIdAsync(Guid employeeId)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", employeeId);

            var sql = "Proc_Employee_GetById";

            var employee = await _connection.QueryFirstOrDefaultAsync<Employee>(sql, param, commandType: CommandType.StoredProcedure);

            if (employee == null)
            {
                throw new NotFoundException($"Nhân viên '{employeeId}' không tồn tại");
            }

            return employee;
        }

        /// <summary>
        /// Lấy nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>Nhân viên (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<Employee> FindByCodeAsync(string employeeCode)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeCode", employeeCode);

            var sql = "Proc_Employee_GetByCode";

            var employee = await _connection.QueryFirstOrDefaultAsync<Employee>(sql, param, commandType: CommandType.StoredProcedure);

            return employee;
        }

        /// <summary>
        /// Tìm nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<Employee?> FindByIdAsync(Guid employeeId)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", employeeId);

            var sql = "Proc_Employee_GetById";

            var employee = await _connection.QueryFirstOrDefaultAsync<Employee>(sql, param, commandType: CommandType.StoredProcedure);

            return employee;
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<string?> FindNewEmployeeCodeAsync()
        {
            var sql = "Proc_Employee_GetNewCode";

            var employee = await _connection.QueryFirstOrDefaultAsync<string>(sql, commandType: CommandType.StoredProcedure);

            return employee;
        }

        /// <summary>
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<int> InsertAsync(Employee employee)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", employee.EmployeeId);
            param.Add("@EmployeeCode", employee.EmployeeCode);
            param.Add("@FullName", employee.FullName);
            param.Add("@DepartmentId", employee.DepartmentId);
            param.Add("@PositionId", employee.PositionId);
            param.Add("@DateOfBirth", employee.DateOfBirth);
            param.Add("@Gender", employee.Gender);
            param.Add("@IdentityNumber", employee.IdentityNumber);
            param.Add("@IdentityDate", employee.IdentityDate);
            param.Add("@IdentityPlace", employee.IdentityPlace);
            param.Add("@Address", employee.Address);
            param.Add("@MobilePhoneNumber", employee.MobilePhoneNumber);
            param.Add("@LandlineNumber", employee.LandlineNumber);
            param.Add("@Email", employee.Email);
            param.Add("@BankAccount", employee.BankAccount);
            param.Add("@BankName", employee.BankName);
            param.Add("@BankBranch", employee.BankBranch);
            param.Add("@CreatedDate", employee.CreatedDate);
            param.Add("@CreatedBy", employee.CreatedBy);
            param.Add("@ModifiedDate", employee.ModifiedDate);
            param.Add("@ModifiedBy", employee.ModifiedBy);

            var sql = "Proc_Employee_Create";

            var result = await _connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<int> UpdateAsync(Employee employee)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", employee.EmployeeId);
            param.Add("@EmployeeCode", employee.EmployeeCode);
            param.Add("@FullName", employee.FullName);
            param.Add("@DepartmentId", employee.DepartmentId);
            param.Add("@PositionId", employee.PositionId);
            param.Add("@DateOfBirth", employee.DateOfBirth);
            param.Add("@Gender", employee.Gender);
            param.Add("@IdentityNumber", employee.IdentityNumber);
            param.Add("@IdentityDate", employee.IdentityDate);
            param.Add("@IdentityPlace", employee.IdentityPlace);
            param.Add("@Address", employee.Address);
            param.Add("@MobilePhoneNumber", employee.MobilePhoneNumber);
            param.Add("@LandlineNumber", employee.LandlineNumber);
            param.Add("@Email", employee.Email);
            param.Add("@BankAccount", employee.BankAccount);
            param.Add("@BankName", employee.BankName);
            param.Add("@BankBranch", employee.BankBranch);
            param.Add("@ModifiedDate", employee.ModifiedDate);
            param.Add("@ModifiedBy", employee.ModifiedBy);

            var sql = "Proc_Employee_UpdateById";

            var result = await _connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Xoá nhân viên theo Id
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<int> DeleteByIdAsync(Employee employee)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", employee.EmployeeId);

            var sql = "Proc_Employee_DeleteById";

            var result = await _connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Xoá nhiều nhân viên
        /// </summary>
        /// <param name="employees">Danh sách nhân viên cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (16/07/2023)
        public async Task<int> DeleteAsync(IEnumerable<Employee> employees)
        {
            var employeeIds = string.Join(", ", employees.Select(employee => employee.EmployeeId));

            var param = new DynamicParameters();
            param.Add("@EmployeeIds", employeeIds);

            var sql = "Proc_Employee_Delete";

            var result = await _connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}

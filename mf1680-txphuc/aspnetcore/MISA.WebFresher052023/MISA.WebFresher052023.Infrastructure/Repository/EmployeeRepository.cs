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
        /// Lấy nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task<Employee> GetByIdAsync(Guid employeeId)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", employeeId);

            var sql = "Proc_Employee_GetById";

            var employee = await _connection.QueryFirstOrDefaultAsync<Employee>(sql, param, commandType: CommandType.StoredProcedure);

            if (employee == null)
            {
                throw new NotFoundException("Nhân viên không tồn tại");
            }

            return employee;
        }

        /// <summary>
        /// Lấy nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>Nhân viên</returns>
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
        /// <returns>Nhân viên</returns>
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
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task InsertAsync(Employee employee)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", Guid.NewGuid());
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

            await _connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task UpdateAsync(Employee employee)
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

            await _connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Xoá nhân viên   
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task DeleteAsync(Employee employee)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", employee.EmployeeId);

            var sql = "Proc_Employee_DeleteById";

            await _connection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);
        }
    }
}

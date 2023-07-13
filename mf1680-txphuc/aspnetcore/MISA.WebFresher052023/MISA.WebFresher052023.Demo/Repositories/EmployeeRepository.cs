using Dapper;
using MISA.WebFresher052023.Demo.Entities;
using MySqlConnector;
using System.Data;

namespace MISA.WebFresher052023.Demo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get toàn bộ nhân viên
        /// </summary>
        /// <returns>Trả về danh sách nhân viên</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var connectionStr = _configuration.GetConnectionString("MisaAccounting");

            using var mySqlConnection = new MySqlConnection(connectionStr);

            try
            {
                mySqlConnection.Open();

                var sql = "Proc_Employee_GetAll";

                var employees = await mySqlConnection.QueryAsync<Employee>(sql, commandType: CommandType.StoredProcedure);

                return employees;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }


        /// <summary>
        /// Get một nhân viên thông qua Id
        /// </summary>
        /// <param name="employeeId">Mã nhân viên</param>
        /// <returns>Trả về một nhân viên thoả mãn</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<Employee> GetById(Guid employeeId)
        {
            var connectionStr = _configuration.GetConnectionString("MisaAccounting");

            using var mySqlConnection = new MySqlConnection(connectionStr);

            try
            {
                mySqlConnection.Open();

                var param = new DynamicParameters();
                param.Add("@EmployeeId", employeeId);

                var sql = "Proc_Employee_GetById";

                var employee = await mySqlConnection.QueryFirstOrDefaultAsync<Employee>(sql, param, commandType: CommandType.StoredProcedure);

                return employee;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        /// <summary>
        /// Tạo nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Trả về nhân viên được tạo thành công</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<int> Create(Employee employee)
        {
            var connectionStr = _configuration.GetConnectionString("MisaAccounting");

            using var mySqlConnection = new MySqlConnection(connectionStr);

            try
            {
                mySqlConnection.Open();

                await Console.Out.WriteLineAsync(Guid.NewGuid().ToString());

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

                var result = await mySqlConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);


                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        public async Task<int> Update(Employee employee)
        {
            return 0;
        }

        /// <summary>
        /// Xoá một nhân viên thông qua Id
        /// </summary>
        /// <param name="employeeId">Mã nhân viên</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (13/07/2023)
        public async Task<int> DeleteById(Guid employeeId)
        {
            var connectionStr = _configuration.GetConnectionString("MisaAccounting");

            using var mySqlConnection = new MySqlConnection(connectionStr);

            try
            {
                mySqlConnection.Open();

                var param = new DynamicParameters();
                param.Add("@EmployeeId", employeeId);

                var sql = "Proc_Employee_DeleteById";

                var result = await mySqlConnection.ExecuteAsync(sql, param, commandType: CommandType.StoredProcedure);

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        /// <summary>
        /// Xoá nhiều nhân viên nhân viên thông qua mảng các Id
        /// </summary>
        /// <param name="employeeIds">Mảng mã nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (13/07/2023)
        public async Task<int> Delete(Guid[] employeeIds)
        {
            return 0;
        }
    }
}

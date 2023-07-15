using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<IEnumerable<Employee>> GetAllAsync();

        /// <summary>
        /// Lấy nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<Employee> GetByIdAsync(Guid employeeId);

        /// <summary>
        /// Lấy nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<Employee> FindByCodeAsync(string employeeCode);

        /// <summary>
        /// Tìm nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<Employee?> FindByIdAsync(Guid employeeId);

        /// <summary>
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task InsertAsync(Employee employee);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task UpdateAsync(Employee employee);

        /// <summary>
        /// Xoá nhân viên   
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task DeleteAsync(Employee employee);
    }
}

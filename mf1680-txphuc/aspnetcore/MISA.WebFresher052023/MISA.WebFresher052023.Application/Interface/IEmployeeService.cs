using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<IEnumerable<EmployeeDto>> GetAllAsync();

        /// <summary>
        /// Lấy nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<EmployeeDto> GetByIdAsync(Guid employeeId);

        /// <summary>
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employeeCreateDto">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task InsertAsync(EmployeeCreateDto employeeCreateDto);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <param name="employeeUpdateDto">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task UpdateAsync(Guid employeeId, EmployeeUpdateDto employeeUpdateDto);

        /// <summary>
        /// Xoá nhân viên   
        /// </summary>
        /// <param name="employeeId">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task DeleteAsync(Guid employeeId);
    }
}

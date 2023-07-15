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
        /// Tìm kiếm, filter và phân trang
        /// </summary>
        /// <param name="search">Search theo tên hoặc mã nhân viên</param>
        /// <param name="currentPage">trang hiện tại</param>
        /// <param name="pageSize">Số phần tử trên trang</param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<Pagination> FilterAsync(string? search, int? currentPage, int? pageSize);

        /// <summary>
        /// Lấy nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<EmployeeDto> GetByIdAsync(Guid employeeId);

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<string?> FindNewEmployeeCodeAsync();

        /// <summary>
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employeeCreateDto">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task<int> InsertAsync(EmployeeCreateDto employeeCreateDto);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <param name="employeeUpdateDto">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task<int> UpdateAsync(Guid employeeId, EmployeeUpdateDto employeeUpdateDto);

        /// <summary>
        /// Xoá nhân viên   
        /// </summary>
        /// <param name="employeeId">Thông tin nhân viên</param>
        /// CreatedBy: txphuc (14/07/2023)
        Task<int> DeleteAsync(Guid employeeId);
    }
}

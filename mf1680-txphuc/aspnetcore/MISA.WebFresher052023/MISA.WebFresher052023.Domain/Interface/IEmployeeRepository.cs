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
        /// Tìm kiếm, filter và phân trang
        /// </summary>
        /// <param name="search">Search theo tên hoặc mã nhân viên</param>
        /// <param name="currentPage">trang hiện tại</param>
        /// <param name="pageSize">Số phần tử trên trang</param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<Pagination> FilterAsync(string search, int currentPage, int pageSize);

        /// <summary>
        /// Lấy nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên (trả về NotFoundException nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<Employee> GetByIdAsync(Guid employeeId);

        /// <summary>
        /// Lấy nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>Nhân viên (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<Employee> FindByCodeAsync(string employeeCode);

        /// <summary>
        /// Tìm nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Nhân viên (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<Employee?> FindByIdAsync(Guid employeeId);

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<string?> FindNewEmployeeCodeAsync();

        /// <summary>
        /// Tạo nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<int> InsertAsync(Employee employee);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<int> UpdateAsync(Employee employee);

        /// <summary>
        /// Xoá nhân viên theo Id
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (14/07/2023)
        Task<int> DeleteByIdAsync(Employee employee);

        /// <summary>
        /// Xoá nhiều nhân viên
        /// </summary>
        /// <param name="employees">Danh sách nhân viên cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (16/07/2023)
        Task<int> DeleteAsync(IEnumerable<Employee> employees);
    }
}

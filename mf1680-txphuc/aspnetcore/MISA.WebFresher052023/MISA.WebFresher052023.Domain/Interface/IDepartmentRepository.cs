using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Lấy toàn bộ danh sách đơn vị
        /// </summary>
        /// <returns>Danh sách đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<IEnumerable<Department>> GetAllAsync();

        /// <summary>
        /// Lấy đơn vị theo Id
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <returns>Thông tin đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<Department> GetByIdAsync(Guid departmentId);

        /// <summary>
        /// Tạo đơn vị mới
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi được thêm</returns>
        Task<int> InsertAsync(Department department);

        /// <summary>
        /// Cập nhật đơn vị
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        Task<int> UpdateAsync(Department department);

        /// <summary>
        /// Xoá một đơn vị
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        Task<int> DeleteAsync(Department department);
    }
}

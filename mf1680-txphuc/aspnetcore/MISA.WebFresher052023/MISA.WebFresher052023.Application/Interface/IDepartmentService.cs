using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Lấy toàn bộ danh sách đơn vị
        /// </summary>
        /// <returns>Danh sách đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<IEnumerable<DepartmentDto>> GetAllAsync();

        /// <summary>
        /// Lấy đơn vị theo Id
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <returns>Thông tin đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<DepartmentDto> GetByIdAsync(Guid departmentId);

        /// <summary>
        /// Tạo đơn vị mới
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi được thêm</returns>
        Task<int> InsertAsync(DepartmentCreateDto departmentCreateDto);

        /// <summary>
        /// Cập nhật đơn vị
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        Task<int> UpdateAsync(Guid departmentId, DepartmentUpdateDto departmentUpdateDto);

        /// <summary>
        /// Xoá một đơn vị
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        Task<int> DeleteAsync(Guid departmentId);
    }
}

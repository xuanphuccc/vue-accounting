using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public interface IBaseRepository<TEntity> : IBaseReadOnlyRepository<TEntity>
    {
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="entity">Data của đối tượng</param>
        /// <returns>Id của bản ghi được thêm</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<Guid> InsertAsync(TEntity entity);

        /// <summary>
        /// Thêm nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách đối tượng</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (22/08/2023)
        Task<int> InsertMultipleAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entity">Data của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Cập nhật nhều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<int> UpdateMultipleAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Xoá đối tượng theo Id
        /// </summary>
        /// <param name="entity">Thông tin đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// Xoá nhiều đối tượng
        /// </summary>
        /// <param name="entityIds">Danh sách Id của đối tượng cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (24/07/2023)
        Task<int> DeleteMultipleAsync(IEnumerable<Guid> entityIds);
    }
}

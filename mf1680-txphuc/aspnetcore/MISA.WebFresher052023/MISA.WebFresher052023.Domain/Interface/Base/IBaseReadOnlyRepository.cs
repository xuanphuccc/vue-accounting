using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IBaseReadOnlyRepository<TEntity, TModel>
    {
        /// <summary>
        /// Lấy tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<IEnumerable<TModel>> GetAllAsync();

        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Đối tượng (trả về NotFoundException nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<TEntity> GetByIdAsync(Guid entityId);

        /// <summary>
        /// Lấy danh sách đối tượng theo Id
        /// </summary>
        /// <param name="entityIds">Danh sách Id</param>
        /// <returns>Danh sách đối tượng thoả mãn</returns>
        /// CreatedBy: txphuc (24/07/2023)
        Task<IEnumerable<TEntity>> GetListByIdsAsync(IEnumerable<Guid> entityIds);

        /// <summary>
        /// Tìm đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Đối tượng (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<TEntity?> FindByIdAsync(Guid entityId);
    }
}

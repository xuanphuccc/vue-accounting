using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public interface IBaseCodeRepository<TEntity, TModel> : IBaseRepository<TEntity, TModel>
    {
        /// <summary>
        /// Lấy đối tượng theo mã
        /// </summary>
        /// <param name="entityCode">Mã</param>
        /// <returns>Đối tượng (trả về null nếu không tìm thấy)</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<TEntity?> FindByCodeAsync(string entityCode);

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<string?> FindNewCodeAsync();
    }
}

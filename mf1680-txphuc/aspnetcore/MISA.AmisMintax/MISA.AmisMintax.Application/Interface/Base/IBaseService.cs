using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public interface IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : 
        IBaseReadOnlyService<TEntityDto>
    {
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="entityCreateDto">Thông tin đối tượng</param>
        /// CreatedBy: txphuc (18/07/2023)
        Task<Guid> InsertAsync(TEntityCreateDto entityCreateDto);

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <param name="entityUpdateDto">Thông tin đối tượng</param>
        /// CreatedBy: txphuc (18/07/2023)
        Task<int> UpdateAsync(Guid entityId, TEntityUpdateDto entityUpdateDto);

        /// <summary>
        /// Cập nhật nhiều đối tượng
        /// </summary>
        /// <param name="entityUpdateDtos">Danh sách đối tượng cần update</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (29/08/2023)
        Task<int> UpdateMultipleAsync(IEnumerable<TEntityUpdateDto> entityUpdateDtos);

        /// <summary>
        /// Xoá đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// CreatedBy: txphuc (18/07/2023)
        Task<int> DeleteAsync(Guid entityId);

        /// <summary>
        /// Xoá nhiều đối tượng
        /// </summary>
        /// <param name="employeeIds">Danh sách Id của các đối tượng cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<int> DeleteMultipleAsync(List<Guid> entityIds);
    }
}

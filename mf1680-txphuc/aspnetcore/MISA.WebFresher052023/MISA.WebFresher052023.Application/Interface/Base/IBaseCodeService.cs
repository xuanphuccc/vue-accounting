using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public interface IBaseCodeService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : 
        IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Task<string?> FindNewCodeAsync();
    }
}

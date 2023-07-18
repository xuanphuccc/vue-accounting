using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public abstract class BaseCodeService<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseService<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto>, IBaseCodeService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        protected readonly IBaseCodeRepository<TEntity> _baseCodeRepository;

        protected BaseCodeService(IBaseCodeRepository<TEntity> baseCodeRepository, IMapper mapper) : base(baseCodeRepository, mapper)
        {
            _baseCodeRepository = baseCodeRepository;
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<string?> FindNewCodeAsync()
        {
            var newCode = await _baseCodeRepository.FindNewCodeAsync();

            return newCode;
        }
    }
}

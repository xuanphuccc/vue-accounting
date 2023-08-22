using AutoMapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public abstract class BaseCodeService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> :
        BaseService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto>,
        IBaseCodeService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> where TEntity: IHasKey
    {
        #region Fields
        protected readonly IBaseCodeRepository<TEntity, TModel> _baseCodeRepository;
        #endregion

        #region Constructors
        protected BaseCodeService(
            IBaseCodeRepository<TEntity, TModel> baseCodeRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) : base(baseCodeRepository, unitOfWork, mapper)
        {
            _baseCodeRepository = baseCodeRepository;
        }
        #endregion

        #region Methods
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
        #endregion
    }
}

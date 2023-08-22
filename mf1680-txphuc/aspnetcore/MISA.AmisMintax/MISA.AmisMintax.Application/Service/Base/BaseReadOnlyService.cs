using AutoMapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public abstract class BaseReadOnlyService<TEntity, TEntityDto> : IBaseReadOnlyService<TEntityDto>
    {
        #region Fields
        protected readonly IBaseReadOnlyRepository<TEntity> _baseReadOnlyRepository;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructors
        protected BaseReadOnlyService(IBaseReadOnlyRepository<TEntity> repository, IMapper mapper)
        {
            _baseReadOnlyRepository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<IEnumerable<TEntityDto>> GetAllAsync()
        {
            var entities = await _baseReadOnlyRepository.GetAllAsync();

            var entityDtos = _mapper.Map<IEnumerable<TEntityDto>>(entities);

            return entityDtos;
        }

        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<TEntityDto> GetByIdAsync(Guid entityId)
        {
            var entity = await _baseReadOnlyRepository.GetByIdAsync(entityId);

            var entityDto = _mapper.Map<TEntityDto>(entity);

            // Custom lại dữ liệu nếu cần
            await CustomDetailData(entityDto);

            return entityDto;
        }

        /// <summary>
        /// Xử lý chỉnh sửa dữ liệu theo yêu cầu
        /// </summary>
        /// <param name="entityDto">Đối tượng cần chỉnh sửa</param>
        /// CreatedBy: txphuc (22/08/2023)
        public virtual Task CustomDetailData(TEntityDto entityDto)
        {
            return Task.FromResult(entityDto);
        }
        #endregion
    }
}

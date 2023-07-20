using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public abstract class BaseReadOnlyService<TEntity, TModel, TEntityDto> : IBaseReadOnlyService<TEntityDto>
    {
        protected readonly IBaseReadOnlyRepository<TEntity, TModel> _baseReadOnlyRepository;
        protected readonly IMapper _mapper;

        protected BaseReadOnlyService(IBaseReadOnlyRepository<TEntity, TModel> repository, IMapper mapper)
        {
            _baseReadOnlyRepository = repository;
            _mapper = mapper;
        }

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

            return entityDto;
        }
    }
}

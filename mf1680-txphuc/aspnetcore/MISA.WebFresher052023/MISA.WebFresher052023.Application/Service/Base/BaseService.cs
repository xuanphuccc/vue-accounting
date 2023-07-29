using AutoMapper;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public abstract class BaseService<TEntity, TModel, TEntityDto, TEntityCreateDto, TEntityUpdateDto> :
        BaseReadOnlyService<TEntity, TModel, TEntityDto>,
        IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        #region Fields
        protected readonly IBaseRepository<TEntity, TModel> _baseRepository;
        protected readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        protected BaseService(
            IBaseRepository<TEntity, TModel> baseRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) : base(baseRepository, mapper)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tạo đối tượng mới
        /// </summary>
        /// <param name="entityCreateDto">Thông tin đối tượng</param>
        /// CreatedBy: txphuc (18/07/2023)
        public virtual async Task<int> InsertAsync(TEntityCreateDto entityCreateDto)
        {
            var entity = await MapCreateDtoToEntityAsync(entityCreateDto);

            if (entity is BaseAuditEntity baseAuditEntity)
            {
                baseAuditEntity.CreatedDate = DateTime.Now;
                baseAuditEntity.CreatedBy = "Helloworld";
            }

            var result = await _baseRepository.InsertAsync(entity);

            return result;
        }

        /// <summary>
        /// Cập nhật đối tượng
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <param name="entityUpdateDto">Thông tin đối tượng</param>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> UpdateAsync(Guid entityId, TEntityUpdateDto entityUpdateDto)
        {
            var entity = await MapUpdateDtoToEntityAsync(entityId, entityUpdateDto);

            var result = await _baseRepository.UpdateAsync(entity);

            return result;
        }

        /// <summary>
        /// Xoá đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> DeleteByIdAsync(Guid entityId)
        {
            // Check đối tượng có tồn tại hay không
            var existEntity = await _baseRepository.GetByIdAsync(entityId);

            var result = await _baseRepository.DeleteByIdAsync(existEntity);

            return result;
        }

        /// <summary>
        /// Xoá nhiều đối tượng
        /// </summary>
        /// <param name="entityIds">Danh sách Id của các đối tượng cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task<int> DeleteAsync(List<Guid> entityIds)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var entities = await _baseRepository.GetListByIdsAsync(entityIds);

                if (entityIds.Count == 0)
                {
                    throw new NotFoundException(ErrorMessage.NotFound, ErrorCode.NotFound);
                }
                else if (entities.ToList().Count < entityIds.Count)
                {
                    throw new NotFoundException(ErrorMessage.NotFound, ErrorCode.NotFound);
                }

                var result = await _baseRepository.DeleteAsync(entities);

                await _unitOfWork.CommitAsync();

                return result;
            }
            catch (NotFoundException)
            {
                await _unitOfWork.RollBackAsync();
                throw;
            }
        }

        /// <summary>
        /// Validate nghiệp vụ cho Insert
        /// </summary>
        /// <param name="entityCreateDto">CreateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected abstract Task<TEntity> MapCreateDtoToEntityAsync(TEntityCreateDto entityCreateDto);

        /// <summary>
        /// Validate nghiệp vụ cho Update
        /// </summary>
        /// <param name="entityUpdateDto">UpdateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected abstract Task<TEntity> MapUpdateDtoToEntityAsync(Guid entityId, TEntityUpdateDto entityUpdateDto);
        #endregion
    }
}

using AutoMapper;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.Common;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class PositionService : BaseCodeService<Position, Position, PositionDto, PositionCreateDto, PositionUpdateDto>, IPositionService
    {
        #region Fields
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionManager _positionManager;
        #endregion

        #region Constructors
        public PositionService(
            IPositionRepository positionRepository,
            IPositionManager positionManager,
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) : base(positionRepository, unitOfWork, mapper)
        {
            _positionRepository = positionRepository;
            _positionManager = positionManager;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate nghiệp vụ tạo mới vị trí
        /// </summary>
        /// <param name="positionCreateDto">Data của vị trí</param>
        /// <returns>Đối tượng đã được validate</returns>
        /// CreatedBy: txphuc (19/07/2023)
        protected override async Task<Position> MapCreateDtoToEntityAsync(PositionCreateDto positionCreateDto)
        {
            // Check trùng mã vị trí
            await _positionManager.CheckExistPositionCode(positionCreateDto.PositionCode);

            var position = _mapper.Map<Position>(positionCreateDto);

            // Set Id cho bản ghi
            position.PositionId = Guid.NewGuid();

            return position;
        }

        /// <summary>
        /// Validate nghiệp vụ cập nhật vị trí
        /// </summary>
        /// <param name="positionId">Id vị trí</param>
        /// <param name="positionUpdateDto">Data của vị trí</param>
        /// <returns>Đối tượng đã validate</returns>
        /// CreatedBy: txphuc (19/07/2023)
        protected override async Task<Position> MapUpdateDtoToEntityAsync(Guid positionId, PositionUpdateDto positionUpdateDto)
        {
            // Check vị trí có tồn tại hay không
            var oldPosition = await _positionRepository.GetByIdAsync(positionId);

            // Check trùng mã vị trí
            await _positionManager.CheckExistPositionCode(positionUpdateDto.PositionCode, oldPosition.PositionCode);

            var newPosition = _mapper.Map(positionUpdateDto, oldPosition);

            return newPosition;
        }

        /// <summary>
        /// Kiểm tra có bản ghi phụ thuộc hay không (cho trường hợp xoá một bản ghi)
        /// </summary>
        /// <param name="positionId">Id của bản ghi</param>
        /// <returns></returns>
        protected override async Task CheckConstraintForDeleteAsync(Guid positionId)
        {
            // Check bản ghi có phụ thuộc hay không
            var postion = await _positionRepository.CheckConstraintByIdAsync(positionId);
            if (postion != null)
            {
                var errorMessage = String.Format(ErrorMessage.ConstraintError, CommonResource.Position, postion.PositionCode);
                throw new ConstraintException(errorMessage, ErrorCode.ConstraintError);
            }
        }

        /// <summary>
        /// Kiểm tra có bản ghi phụ thuộc hay không (cho trường hợp xoá nhiều)
        /// </summary>
        /// <param name="positionIds">Danh sách Id của bản ghi</param>
        /// <returns></returns>
        protected override async Task<IEnumerable<Position>> CheckConstraintForDeleteManyAsync(List<Guid> positionIds)
        {
            var positionHaveConstraints = await _positionRepository.CheckListConstraintAsync(positionIds);

            return positionHaveConstraints;
        }
        #endregion
    }
}

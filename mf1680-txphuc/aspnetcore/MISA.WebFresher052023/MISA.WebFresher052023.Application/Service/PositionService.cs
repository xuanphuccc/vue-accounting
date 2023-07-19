using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class PositionService : BaseCodeService<Position, PositionDto, PositionCreateDto, PositionUpdateDto>, IPositionService
    {
        #region Fields
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionManager _positionManager;
        #endregion

        #region Constructor
        public PositionService(
            IPositionRepository positionRepository,
            IPositionManager positionManager,
            IMapper mapper) : base(positionRepository, mapper)
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

            // Set thông tin cho bản ghi
            position.PositionId = Guid.NewGuid();
            position.CreatedDate = DateTime.Now;
            position.CreatedBy = "txphuc";
            position.ModifiedDate = DateTime.Now;
            position.ModifiedBy = "txphuc";

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

            // Set lại ngày chỉnh sửa cho bản ghi
            newPosition.ModifiedDate = DateTime.Now;
            newPosition.ModifiedBy = "txphuc";

            return newPosition;
        }
        #endregion
    }
}

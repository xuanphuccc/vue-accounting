using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class PositionService : IPositionService
    {
        #region Fields
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionManager _positionManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public PositionService(IPositionRepository positionRepository, IPositionManager positionManager, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _positionManager = positionManager;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy danh sách toàn bộ vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<IEnumerable<PositionDto>> GetAllAsync()
        {
            var positions = await _positionRepository.GetAllAsync();

            var positionDtos = _mapper.Map<IEnumerable<PositionDto>>(positions);

            return positionDtos;
        }

        /// <summary>
        /// Lấy thông tin một vị trí
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Thông tin vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<PositionDto> GetByIdAsync(Guid positionId)
        {
            var position = await _positionRepository.GetByIdAsync(positionId);

            var positionDto = _mapper.Map<PositionDto>(position);

            return positionDto;
        }

        /// <summary>
        /// Thêm mới một vị trí
        /// </summary>
        /// <param name="positionCreateDto">Thông tin vị trí</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> InsertAsync(PositionCreateDto positionCreateDto)
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

            var result = await _positionRepository.InsertAsync(position);

            return result;
        }

        /// <summary>
        /// Cập nhật một vị trí
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <param name="positionUpdateDto">Thông tin vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> UpdateAsync(Guid positionId, PositionUpdateDto positionUpdateDto)
        {
            // Check vị trí có tồn tại hay không
            var oldPosition = await _positionRepository.GetByIdAsync(positionId);

            // Check trùng mã vị trí
            await _positionManager.CheckExistPositionCode(positionUpdateDto.PositionCode, oldPosition.PositionCode);

            var newPosition = _mapper.Map(positionUpdateDto, oldPosition);

            // Set lại ngày chỉnh sửa cho bản ghi
            newPosition.ModifiedDate = DateTime.Now;
            newPosition.ModifiedBy = "txphuc";

            var result = await _positionRepository.UpdateAsync(newPosition);

            return result;
        }

        /// <summary>
        /// Xoá một vị trí
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> DeleteAsync(Guid positionId)
        {
            // Check vị trí có tồn tại hay không
            var existPosition = await _positionRepository.GetByIdAsync(positionId);

            var result = await _positionRepository.DeleteAsync(existPosition);

            return result;
        } 
        #endregion
    }
}

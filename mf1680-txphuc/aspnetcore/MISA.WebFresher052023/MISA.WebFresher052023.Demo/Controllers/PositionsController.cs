using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;

namespace MISA.WebFresher052023.Demo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        #region Fields
        private readonly IPositionService _positionService;
        #endregion

        #region Constructor
        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy danh sách toàn bộ vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var positions = await _positionService.GetAllAsync();

            return Ok(positions);
        }

        /// <summary>
        /// Lấy thông tin một vị trí
        /// </summary>
        /// <param name="id">Id của vị trí</param>
        /// <returns>Thông tin vị trí</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var position = await _positionService.GetByIdAsync(id);

            return Ok(position);
        }

        /// <summary>
        /// Thêm mới một vị trí
        /// </summary>
        /// <param name="positionCreateDto">Thông tin vị trí</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PositionCreateDto positionCreateDto)
        {
            var result = await _positionService.InsertAsync(positionCreateDto);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Sửa một vị trí
        /// </summary>
        /// <param name="id">Id của vị trí</param>
        /// <param name="positionUpdateDto">Thông tin vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] PositionUpdateDto positionUpdateDto)
        {
            var result = await _positionService.UpdateAsync(id, positionUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Xoá một vị trí  
        /// </summary>
        /// <param name="id">Id của vị trí</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var result = await _positionService.DeleteAsync(id);

            return Ok(result);
        } 
        #endregion
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AmisMintax.Application;

namespace MISA.AmisMintax
{
    public abstract class BaseController<TEntityDto, TEntityCreateDto, TEntityUpdateDto> :
        BaseReadOnlyController<TEntityDto>
    {
        #region Fields
        protected readonly IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> _baseService;
        #endregion

        #region Constructors
        protected BaseController(IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Endpoints
        /// <summary>
        /// Tạo mới một đối tượng
        /// </summary>
        /// <param name="entityCreateDto">Data đối tượng cần tạo</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TEntityCreateDto entityCreateDto)
        {
            var result = await _baseService.InsertAsync(entityCreateDto);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Sửa đối tượng theo id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <param name="entityUpdateDto">Data đối tượng cần sửa</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] TEntityUpdateDto entityUpdateDto)
        {
            var result = await _baseService.UpdateAsync(id, entityUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Sửa hàng loạt bản ghi
        /// </summary>
        /// <param name="entityUpdateDtos">Danh sách bản ghi cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (28/08/2023)
        [HttpPut]
        public async Task<IActionResult> UpdateMultipleAsync([FromBody] List<TEntityUpdateDto> entityUpdateDtos)
        {
            var result = await _baseService.UpdateMultipleAsync(entityUpdateDtos);

            return Ok(result);
        }

        /// <summary>
        /// Xoá một đối tượng theo Id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] Guid id)
        {
            var result = await _baseService.DeleteAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Xoá nhiều đối tượng theo Id
        /// </summary>
        /// <param name="entityIds">Danh sách mã cần xoá</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpDelete]
        public async Task<IActionResult> DeleteMultipleAsync([FromBody] List<Guid> entityIds)
        {
            var result = await _baseService.DeleteMultipleAsync(entityIds);

            return Ok(result);
        } 
        #endregion
    }
}

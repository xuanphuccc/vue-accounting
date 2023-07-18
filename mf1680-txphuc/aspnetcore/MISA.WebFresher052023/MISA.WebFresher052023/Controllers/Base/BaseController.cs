using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;

namespace MISA.WebFresher052023
{
    public abstract class BaseController<TEntityDto, TEntityCreateDto, TEntityUpdateDto> :
        BaseReadOnlyController<TEntityDto>
    {
        protected readonly IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> _baseService;

        protected BaseController(IBaseService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseService) : base(baseService)
        {
            _baseService = baseService;
        }

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
        /// Xoá một đối tượng theo Id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] Guid id)
        {
            var result = await _baseService.DeleteByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Xoá nhiều đối tượng theo Id
        /// </summary>
        /// <param name="entityIds">Danh sách mã cần xoá</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] IEnumerable<Guid> entityIds)
        {
            var result = await _baseService.DeleteAsync(entityIds);

            return Ok(result);
        }
    }
}

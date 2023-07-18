using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;

namespace MISA.WebFresher052023
{
    public abstract class BaseReadOnlyController<TEntityDto> : ControllerBase
    {
        protected readonly IBaseReadOnlyService<TEntityDto> _baseReadOnlyService;

        protected BaseReadOnlyController(IBaseReadOnlyService<TEntityDto> baseReadOnlyService)
        {
            _baseReadOnlyService = baseReadOnlyService;
        }

        /// <summary>
        /// Get toàn bộ danh sách đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var entityDtos = await _baseReadOnlyService.GetAllAsync();

            return Ok(entityDtos);
        }

        /// <summary>
        /// Get một đối tượng thông qua Id
        /// </summary>
        /// <param name="id">Mã đối tượng</param>
        /// <returns>Trả về thông tin một đối tượng tìm được</returns> 
        /// CreatedBy: txphuc (18/07/2023)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var entityDto = await _baseReadOnlyService.GetByIdAsync(id);

            return Ok(entityDto);
        }
    }
}

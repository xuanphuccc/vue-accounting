using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;

namespace MISA.WebFresher052023.Controllers.Base
{
    public class BaseCodeController<TEntityDto, TEntityCreateDto, TEntityUpdateDto> :
        BaseController<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        protected readonly IBaseCodeService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> _baseCodeService;

        public BaseCodeController(
            IBaseCodeService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseCodeService) : base(baseCodeService)
        {
            _baseCodeService = baseCodeService;
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// CreatedBy: txphuc (18/07/2023)
        [HttpGet("NewCode")]
        public async Task<IActionResult> FindNewEmployeeCodeAsync()
        {
            var newCode = await _baseCodeService.FindNewCodeAsync();

            return Ok(newCode);
        }
    }
}

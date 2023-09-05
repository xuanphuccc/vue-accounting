using Microsoft.AspNetCore.Mvc;
using MISA.AmisMintax.Application;

namespace MISA.AmisMintax.Controllers.Base
{
    public class BaseCodeController<TEntityDto, TEntityCreateDto, TEntityUpdateDto> :
        BaseController<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
    {
        #region Fields
        protected readonly IBaseCodeService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> _baseCodeService;
        #endregion

        #region Constructors
        public BaseCodeController(
            IBaseCodeService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> baseCodeService) : base(baseCodeService)
        {
            _baseCodeService = baseCodeService;
        }
        #endregion

        #region Endpoints
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
        #endregion
    }
}

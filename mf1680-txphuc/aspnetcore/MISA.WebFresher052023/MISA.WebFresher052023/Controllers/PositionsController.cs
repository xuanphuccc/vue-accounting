using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Controllers.Base;

namespace MISA.WebFresher052023.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : BaseCodeController<PositionDto, PositionCreateDto, PositionUpdateDto>
    {
        private readonly IPositionService _positionService;

        public PositionsController(IPositionService positionService) : base(positionService)
        {
            _positionService = positionService;
        }
    }
}

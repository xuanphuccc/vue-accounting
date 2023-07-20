using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Controllers.Base;
using MISA.WebFresher052023.Domain;

namespace MISA.WebFresher052023.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseCodeController<DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService, IStringLocalizer<ErrorMessages> localizer) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}

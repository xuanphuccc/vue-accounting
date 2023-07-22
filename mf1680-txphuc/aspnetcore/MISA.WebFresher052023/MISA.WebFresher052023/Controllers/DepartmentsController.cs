using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Controllers.Base;
using MISA.WebFresher052023.Domain;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace MISA.WebFresher052023.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseCodeController<DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}

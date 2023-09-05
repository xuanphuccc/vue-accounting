using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AmisMintax.Application;

namespace MISA.AmisMintax.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeRelationshipsController :
        BaseController<EmployeeRelationshipDto, EmployeeRelationshipCreateDto, EmployeeRelationshipUpdateDto>
    {
        #region Constructors
        public EmployeeRelationshipsController(
            IEmployeeRelationshipService employeeRelationshipService) : base(employeeRelationshipService)
        {
        } 
        #endregion
    }
}

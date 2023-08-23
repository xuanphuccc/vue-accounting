using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AmisMintax.Application;
using MISA.AmisMintax.Controllers.Base;
using MISA.AmisMintax.Domain;
using MISA.AmisMintax.Domain.Interface;

namespace MISA.AmisMintax.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseCodeController<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRelationshipRepository _employeeRelationshipRepository;
        public EmployeesController(IEmployeeService employeeService, IEmployeeRelationshipRepository employeeRelationshipRepository) : base(employeeService)
        {
            _employeeService = employeeService;
            _employeeRelationshipRepository = employeeRelationshipRepository;
        }

        /// <summary>
        /// Tìm kiếm, filter và phân trang nhân viên
        /// </summary>
        /// <param name="employeeFilterDto">Các param cho filter và phân trang</param>
        /// <returns>Danh sách nhân viên được lọc và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpPost("Filter")]
        public async Task<IActionResult> FilterAsync([FromBody] EmployeeFilterDto employeeFilterDto)
        {
            var pagedEmployees = await _employeeService.FilterAsync(employeeFilterDto);

            return Ok(pagedEmployees);
        }

        [HttpPost("Test")]
        public async Task<IActionResult> InsertMultipleTest([FromBody] List<EmployeeRelationship> employeeRelationshipCreateDto)
        {
            foreach (var item in employeeRelationshipCreateDto)
            {
                item.EmployeeRelationshipID = Guid.NewGuid();
                item.EmployeeID = new Guid("11452b0c-768e-5ff7-0d63-eeb1d8ed8cef");
                item.FullName = "Test";
                item.Relationship = 9;
            }

            var result = await _employeeRelationshipRepository.InsertMultipleAsync(employeeRelationshipCreateDto);

            return Ok();
        }
    }
}

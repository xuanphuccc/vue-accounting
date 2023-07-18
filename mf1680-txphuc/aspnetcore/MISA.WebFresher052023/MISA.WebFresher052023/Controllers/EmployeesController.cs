using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;
using System.Data;

namespace MISA.WebFresher052023.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        #region Fields
        private readonly IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: txphuc (13/07/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _employeeService.GetAllAsync();

            return Ok(employees);
        }

        /// <summary>
        /// Tìm kiếm, filter và phân trang nhân viên
        /// </summary>
        /// <param name="search">Tìm theo tên hoặc mã nhân viên</param>
        /// <param name="page">Trang hiện tại</param>
        /// <param name="pageSize">Số phần tử trên trang</param>
        /// <returns>Danh sách nhân viên được lọc và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpGet("Filter")]
        public async Task<IActionResult> FilterAsync([FromQuery] string? search, [FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var pagedEmployees = await _employeeService.FilterAsync(search, page, pageSize);

            return Ok(pagedEmployees);
        }

        /// <summary>
        /// Get một nhân viên thông qua Id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <returns>Trả về thông tin một nhân viên tìm được</returns> 
        /// CreatedBy: txphuc (12/07/2023)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            return Ok(employee);
        }

        [HttpGet("NewEmployeeCode")]
        public async Task<IActionResult> FindNewEmployeeCodeAsync()
        {
            var newEmployeeCode = await _employeeService.FindNewEmployeeCodeAsync();

            return Ok(newEmployeeCode);
        }

        /// <summary>
        /// Tạo mới một nhân viên
        /// </summary>
        /// <param name="employeeCreateDto">Data nhân viên cần tạo</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            var result = await _employeeService.InsertAsync(employeeCreateDto);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Sửa nhân viên theo id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <param name="employeeUpdateDto">Data nhân viên cần sửa</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            var result = await _employeeService.UpdateAsync(id, employeeUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Xoá một nhân viên theo Id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] Guid id)
        {
            var result = await _employeeService.DeleteByIdAsync(id);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] IEnumerable<Guid> employeeIds)
        {
            var result = await _employeeService.DeleteAsync(employeeIds);

            return Ok(result);
        }
        #endregion
    }
}

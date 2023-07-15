using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;

namespace MISA.WebFresher052023.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Lấy danh sách tất cả đơn vị
        /// </summary>
        /// <returns>Danh sách đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var departments = await _departmentService.GetAllAsync();

            return Ok(departments);
        }

        /// <summary>
        /// Lấy thông tin một đơn vị
        /// </summary>
        /// <param name="id">Id của đơn vị</param>
        /// <returns>Đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            return Ok(department);
        }

        /// <summary>
        /// Thêm mới một đơn vị
        /// </summary>
        /// <param name="departmentCreateDto">Thông tin đơn vị</param>
        /// <returns>Số bản ghi được thêm thành công</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentCreateDto departmentCreateDto)
        {
            var result = await _departmentService.InsertAsync(departmentCreateDto);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Sửa một đơn vị
        /// </summary>
        /// <param name="id">Id của đơn vị</param>
        /// <param name="departmentUpdateDto">Thông tin đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] DepartmentUpdateDto departmentUpdateDto)
        {
            var result = await _departmentService.UpdateAsync(id, departmentUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Xoá một đơn vị
        /// </summary>
        /// <param name="id">Id của đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync([FromRoute] Guid id)
        {
            var result = await _departmentService.DeleteAsync(id);

            return Ok(result);
        }
    }
}

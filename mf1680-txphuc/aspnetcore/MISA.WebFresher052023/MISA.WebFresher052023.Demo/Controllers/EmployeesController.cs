using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;
using MySqlConnector;
using System.Data;

namespace MISA.WebFresher052023.Demo.Controllers
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
        /// Get một nhân viên thông qua Id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <returns>Trả về thông tin một nhân viên tìm được</returns> 
        /// CreatedBy: txphuc (12/07/2023)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            return Ok(employee);
        }

        /// <summary>
        /// Tạo mới một nhân viên
        /// </summary>
        /// <param name="employeeCreateDto">Data nhân viên cần tạo</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            await _employeeService.InsertAsync(employeeCreateDto);

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Sửa nhân viên theo id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <param name="employeeUpdateDto">Data nhân viên cần sửa</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            await _employeeService.UpdateAsync(id, employeeUpdateDto);

            return Ok();
        }

        /// <summary>
        /// Xoá một nhân viên theo Id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            await _employeeService.DeleteAsync(id);

            return Ok();
        }
        #endregion
    }
}

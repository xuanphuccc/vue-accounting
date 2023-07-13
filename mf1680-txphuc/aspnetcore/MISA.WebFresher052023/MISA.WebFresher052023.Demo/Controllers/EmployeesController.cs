using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Demo.Dtos;
using MISA.WebFresher052023.Demo.Entities;
using MISA.WebFresher052023.Demo.Services;
using MySqlConnector;
using System.Data;

namespace MISA.WebFresher052023.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Get toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: txphuc (13/07/2023)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var employees = await _employeeService.GetAll();

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
            var employee = await _employeeService.GetById(id);

            // Nếu không tìm thấy thì trả về notfound
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        /// <summary>
        /// Tạo mới một nhân viên
        /// </summary>
        /// <param name="employeeRequestDto"></param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequestDto employeeRequestDto)
        {
            var result = await _employeeService.Create(employeeRequestDto);

            return Ok(result);
        }

        /// <summary>
        /// Xoá một nhân viên theo Id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            var result = await _employeeService.DeleteById(id);

            return Ok(result);
        }
    }
}

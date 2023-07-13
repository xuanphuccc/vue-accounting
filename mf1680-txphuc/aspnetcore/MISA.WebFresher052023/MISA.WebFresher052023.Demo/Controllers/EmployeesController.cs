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
    [Route("api/v1/[controller]")]
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
            try
            {
                var employees = await _employeeService.GetAll();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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
            try
            {
                var employee = await _employeeService.GetById(id);

                // Nếu không tìm thấy thì trả về notfound
                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Tạo mới một nhân viên
        /// </summary>
        /// <param name="employeeRequestDto">Data nhân viên cần tạo</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                // Validate dữ liệu
                if (!ModelState.IsValid)
                {
                    return HandleValidate();
                }

                var result = await _employeeService.Create(employeeRequestDto);

                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Sửa nhân viên theo id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <param name="employeeRequestDto">Data nhân viên cần sửa</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                // Kiểm tra nhân viên có tồn tại hay không
                var employee = await _employeeService.GetById(id);

                if (employee == null)
                {
                    return NotFound(new
                    {
                        ErrorCode = StatusCodes.Status404NotFound,
                        UserMsg = "Nhân viên không tồn tại",
                        DevMsg = "Nhân viên không tồn tại"
                    });
                }

                // Validate dữ liệu
                if (!ModelState.IsValid)
                {
                    return HandleValidate();
                }

                // Kiểm tra mã nhân viên có bị trùng hay không
                

                var result = await _employeeService.Update(id, employeeRequestDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Xoá một nhân viên theo Id
        /// </summary>
        /// <param name="id">Mã nhân viên</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            try
            {
                // Kiểm tra nhân viên có tồn tại hay không
                var employee = await _employeeService.GetById(id);

                if (employee == null)
                {
                    return NotFound(new
                    {
                        ErrorCode = StatusCodes.Status404NotFound,
                        UserMsg = "Nhân viên không tồn tại",
                        DevMsg = "Nhân viên không tồn tại"
                    });
                }

                var result = await _employeeService.DeleteById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private IActionResult HandleValidate()
        {
            var errors = ModelState.Values.SelectMany(state => state.Errors)
                                        .Select(error => error.ErrorMessage)
                                        .ToList();

            return BadRequest(new
            {
                ErrorCode = StatusCodes.Status400BadRequest,
                UserMsg = string.Join(", ", errors),
                DevMsg = string.Join(", ", errors)
            });
        }
    }
}

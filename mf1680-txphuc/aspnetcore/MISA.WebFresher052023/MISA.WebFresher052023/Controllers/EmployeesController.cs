using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Controllers.Base;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;

namespace MISA.WebFresher052023.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseCodeController<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeExcelService _employeeExcelService;
        #endregion
        public EmployeesController(IEmployeeService employeeService, IEmployeeExcelService employeeExcelService) : base(employeeService)
        {
            _employeeService = employeeService;
            _employeeExcelService = employeeExcelService;
        }
        #region Constructor

        #endregion

        #region Methods
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
        /// Xuất Excel danh sách nhân viên
        /// </summary>
        /// <returns>File Excel danh sách nhân viên</returns>
        /// CreatedBy: txphuc (23/07/2023)
        [HttpGet("Excel")]
        public async Task<IActionResult> ExportToExcel()
        {
            var bytes = await _employeeExcelService.ExportToExcelAsync();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "employees.xlsx");
        }

        /// <summary>
        /// Nhập Excel danh sách nhân viên (Test)
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: txphuc (23/07/2023)
        [HttpPost("Excel")]
        public async Task<IActionResult> UploadExcel(IFormFile employees)
        {
            if (ModelState.IsValid)
            {
                if (employees.Length > 0)
                {
                    // convert to a stream
                    var stream = employees.OpenReadStream();


                    using var excelPackage = new ExcelPackage(stream);

                    var worksheet = excelPackage.Workbook.Worksheets.First();
                    var rowsCount = worksheet.Dimension.Rows;

                    List<EmployeeCreateDto> employeeCreateDtos = new();

                    for (var row = 2; row <= rowsCount; row++)
                    {
                        var employeeCode = worksheet.Cells[row, 1].Value?.ToString();
                        var fullName = worksheet.Cells[row, 2].Value?.ToString();
                        //var departmentCode = worksheet.Cells[row, 3].Value?.ToString();
                        //var positionCode = worksheet.Cells[row, 4].Value?.ToString();

                        var employeeCreateDto = new EmployeeCreateDto()
                        {
                            EmployeeCode = employeeCode,
                            FullName = fullName,
                        };

                        employeeCreateDtos.Add(employeeCreateDto);
                    }

                    return Ok(employeeCreateDtos);

                }
            }

            return BadRequest();
        }
        #endregion
    }
}

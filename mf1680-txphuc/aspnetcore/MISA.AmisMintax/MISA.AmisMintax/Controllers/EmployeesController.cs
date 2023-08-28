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
        private readonly IEmployeeExcelService _employeeExcelService;
        public EmployeesController(IEmployeeService employeeService, IEmployeeExcelService employeeExcelService) : base(employeeService)
        {
            _employeeService = employeeService;
            _employeeExcelService = employeeExcelService;
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

        /// <summary>
        /// Đếm số bản ghi đang được sử dụng
        /// </summary>
        /// <returns>Số bản ghi đang được sử dụng và tổng số bản ghi</returns>
        /// CreatedBy: txphuc (25/08/2023)
        [HttpGet("UsageCount")]
        public async Task<IActionResult> GetUsageCountAsync()
        {
            var usageCount = await _employeeService.GetUsageCountAsync();

            return Ok(usageCount);
        }

        /// <summary>
        /// Xuất dữ liệu ra file Excel
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: txphuc (29/08/2023)
        [HttpPost("Excel/Export")]
        public async Task<IActionResult> Test([FromBody] ExcelExportRequestDto exportRequestDto)
        {
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "employees.xlsx";

            if (exportRequestDto.EntityIds.Count > 0)
            {
                var exportListbytes = await _employeeExcelService.ExportListToExcelAsync(exportRequestDto.EntityIds, exportRequestDto.ExcelExportSheets);

                return File(exportListbytes, contentType, fileName);
            }

            var exportAllbytes = await _employeeExcelService.ExportAllToExcelAsync(exportRequestDto.ExcelExportSheets);

            return File(exportAllbytes, contentType, fileName);
        }
    }
}

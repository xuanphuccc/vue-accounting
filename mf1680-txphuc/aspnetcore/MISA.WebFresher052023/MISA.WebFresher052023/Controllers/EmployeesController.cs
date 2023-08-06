using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Controllers.Base;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.WebSockets;

namespace MISA.WebFresher052023.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseCodeController<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeExcelService _employeeExcelService;
        private readonly IWebHostEnvironment _webhostEnvironment;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService, IEmployeeExcelService employeeExcelService, IWebHostEnvironment webhostEnvironment) : base(employeeService)
        {
            _employeeService = employeeService;
            _employeeExcelService = employeeExcelService;
            _webhostEnvironment = webhostEnvironment;
        }

        #endregion

        #region Methods
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
        /// Xuất Excel danh sách nhân viên
        /// </summary>
        /// <returns>File Excel danh sách nhân viên</returns>
        /// CreatedBy: txphuc (23/07/2023)
        [HttpPost("Excel/Export")]
        public async Task<IActionResult> ExportToExcel([FromBody] ExcelExportRequestDto excelRequestDto)
        {
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "employees.xlsx";

            // Xuất theo các bản ghi được chọn
            if (excelRequestDto.EntityIds.Count > 0)
            {
                var bytes = await _employeeExcelService.ExportList(excelRequestDto.EntityIds, excelRequestDto.Columns);

                return File(bytes, contentType, fileName);
            }

            // Xuất toàn bộ danh sách
            var allRecordsBytes = await _employeeExcelService.ExportAll(excelRequestDto.Columns);

            return File(allRecordsBytes, contentType, fileName);
        }

        /// <summary>
        /// (TEST)
        /// Tải lên file Excel cần đọc
        /// </summary>
        /// <param name="file">File Excel</param>
        /// <returns>Tên file đã được tải lên thành công</returns>
        /// CreatedBy: txphuc (30/07/2023)
        [HttpPost("Excel/Upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var fileName = "import" + ".xlsx";
            var filePath = Path.Combine(_webhostEnvironment.ContentRootPath, "StaticFile", "Excel", fileName);

            using var stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);

            return Ok(fileName);
        }

        /// <summary>
        /// (TEST)
        /// Lấy tên các cột và vị trí trong file Excel
        /// Lấy tên các thuộc tính của đối tượng cần lấy dữ liệu
        /// </summary>
        /// <param name="excelGetMapDto">Thông tin của file Excel</param>
        /// <returns>Danh sách các cột Excel và danh sách các thuộc tính của đối tượng</returns>
        /// CreatedBy: txphuc (30/07/2023)
        [HttpPost("Excel/GetMap")]
        public IActionResult GetMap([FromBody] ExcelGetMapDto excelGetMapDto)
        {
            var excelMapResponseDto = _employeeExcelService.GetMapExcel(excelGetMapDto);

            return Ok(excelMapResponseDto);
        }

        /// <summary>
        /// (TEST)
        /// - Đọc file Excel theo map đã được gửi lên
        /// và chuyển dữ liệu trong file Excel thành đối tượng
        /// - Validate dữ liệu
        /// - Gửi danh sách các đối tượng đã validate cho FE
        /// </summary>
        /// <param name="mapRequestDto">Danh sách map</param>
        /// <returns>Danh sách các đối tượng đã được validate</returns>
        /// CreatedBy: txphuc (30/07/2023)
        [HttpPost("Excel/Validate")]
        public IActionResult ValidateData([FromBody] ExcelMapRequestDto mapRequestDto)
        {
            var employeeExcelInsertDtos = _employeeExcelService.ReadExcelData(mapRequestDto);

            return Ok(employeeExcelInsertDtos);
        }
        #endregion
    }
}

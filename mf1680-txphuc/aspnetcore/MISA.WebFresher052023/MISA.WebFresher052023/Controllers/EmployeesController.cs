using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Controllers.Base;
using OfficeOpenXml;
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

        #endregion
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
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

        [HttpGet("Excel")]
        public async Task<IActionResult> ExportToExcel()
        {
            // Lấy danh sách nhân viên
            var employees = await _employeeService.GetAllAsync();

            // Tạo luồng download file
            var stream = new MemoryStream();

            using var excelPackage = new ExcelPackage(stream);

            // Định nghĩa một trang tính
            var worksheet = excelPackage.Workbook.Worksheets.Add("Nhân viên");

            // Tạo kiểu
            var customStyle = excelPackage.Workbook.Styles.CreateNamedStyle("CustomStyle");
            customStyle.Style.Font.UnderLine = true;
            customStyle.Style.Font.Color.SetColor(Color.Red);

            // Dòng đầu tiên
            var startRow = 5;
            var row = startRow;

            worksheet.Cells["A1"].Value = "Danh sách nhân viên";
            using var r = worksheet.Cells["A1:L1"];
            r.Merge = true;
            r.Style.Font.Color.SetColor(Color.Green);
            r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));

            worksheet.Cells["A4"].Value = "Mã nhân viên";
            worksheet.Cells["B4"].Value = "Tên nhân viên";
            worksheet.Cells["C4"].Value = "Giới tính";
            worksheet.Cells["D4"].Value = "Ngày sinh";
            worksheet.Cells["E4"].Value = "Số CMND";
            worksheet.Cells["F4"].Value = "Chức danh";
            worksheet.Cells["G4"].Value = "Đơn vị";
            worksheet.Cells["H4"].Value = "Số tài khoản";
            worksheet.Cells["I4"].Value = "Tên ngân hàng";
            worksheet.Cells["J4"].Value = "Chi nhánh TK ngân hàng";

            row = 5;
            foreach (var employee in employees)
            {
                worksheet.Cells[row, 1].Value = employee.EmployeeCode;
                worksheet.Cells[row, 2].Value = employee.FullName;
                worksheet.Cells[row, 3].Value = employee.Gender;
                worksheet.Cells[row, 4].Value = employee.DateOfBirth;
                worksheet.Cells[row, 5].Value = employee.IdentityNumber;
                worksheet.Cells[row, 6].Value = employee.PositionName;
                worksheet.Cells[row, 7].Value = employee.DepartmentName;
                worksheet.Cells[row, 8].Value = employee.BankAccount;
                worksheet.Cells[row, 9].Value = employee.BankName;
                worksheet.Cells[row, 10].Value = employee.BankBranch;

                row++;
            }

            excelPackage.Workbook.Properties.Title = "Danh sách nhân viên";
            excelPackage.Workbook.Properties.Author = "txphuc";

            excelPackage.Save();

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "employees.xlsx");

        }
        #endregion
    }
}

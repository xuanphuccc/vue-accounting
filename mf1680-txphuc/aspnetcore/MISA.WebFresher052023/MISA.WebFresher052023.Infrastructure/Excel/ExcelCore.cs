using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.Common;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public abstract class ExcelCore<TEntityDto, TEntityExcelInsertDto> : IExcelCore<TEntityDto, TEntityExcelInsertDto>
    {
        #region Fields
        protected string SheetName { get; set; } = "Sheet 1";
        protected string SheetTitle { get; set; } = "Sheet title";
        #endregion

        #region Methods
        /// <summary>
        /// Xử lý xuất file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (23/07/2023)
        public byte[] ExportToExcel(IEnumerable<TEntityDto> entityDtos, IEnumerable<ExcelColumnDto> columns)
        {
            // Tạo luồng download file
            var stream = new MemoryStream();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using var excelPackage = new ExcelPackage(stream);

            // Định nghĩa một trang tính
            var worksheet = excelPackage.Workbook.Worksheets.Add(SheetName);

            // Định nghĩa style chung
            var cellStyle = excelPackage.Workbook.Styles.CreateNamedStyle("CellStyle");
            cellStyle.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            cellStyle.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            cellStyle.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            cellStyle.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            cellStyle.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            cellStyle.Style.Font.Name = "Arial";

            // Tổng số cột
            var bonusOrderCol = 1;
            var totalColumns = columns.ToList().Count + bonusOrderCol;

            // Tạo kiểu cho tiêu đề
            worksheet.Cells["A1"].Value = SheetTitle;
            using var titleRange = worksheet.Cells[1, 1, 1, totalColumns];
            titleRange.Merge = true;
            titleRange.Style.Font.Size = 16;
            titleRange.Style.Font.Name = "Arial";
            titleRange.Style.Font.Bold = true;
            titleRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            titleRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Rows[1].Height = 28;

            // Tên các cột theo danh sách và thứ tự được cung cấp
            var headerRowIndex = 3;
            var orderColIndex = 1;
            worksheet.Cells[headerRowIndex, orderColIndex].Value = CommonResource.Order;

            var properties = typeof(TEntityDto).GetProperties();

            foreach (var property in properties)
            {
                // Tìm thông tin cột tương ứng với tên thuộc tính
                var column = columns.FirstOrDefault(col => col.ColumnName.ToLower() == property.Name.ToLower());

                // Ghi tên cột ra file Excel
                if (column != null)
                {
                    worksheet.Cells[headerRowIndex, column.Index + orderColIndex].Value = AttributeGetter.GetDisplayAttribute(property);
                }
            }

            // Style cho tên cột
            using var columnNameRange = worksheet.Cells[headerRowIndex, 1, headerRowIndex, totalColumns];
            columnNameRange.StyleName = cellStyle.Name;
            columnNameRange.Style.Font.Bold = true;
            columnNameRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            columnNameRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
            columnNameRange.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            worksheet.Rows[headerRowIndex].Height = 28;

            // Nội dung
            var currentRow = 4;
            var order = 1;
            foreach (var entityDto in entityDtos)
            {
                // Tạo kiểu cho các ô và các hàng
                worksheet.Cells[currentRow, 1, currentRow, totalColumns].StyleName = cellStyle.Name;
                worksheet.Cells.AutoFitColumns();
                worksheet.Rows[currentRow].Height = 28;

                // Số thứ tự
                worksheet.Cells[currentRow, orderColIndex].Value = order;

                foreach (var property in properties)
                {
                    // Tìm thông tin cột tương ứng với tên thuộc tính
                    var column = columns.FirstOrDefault(col => col.ColumnName.ToLower() == property.Name.ToLower());

                    if (column != null)
                    {
                        var value = property.GetValue(entityDto);

                        FormatData(worksheet, currentRow, column.Index + orderColIndex, value, column.Align);
                    }
                }

                currentRow++;
                order++;
            }

            excelPackage.Save();

            stream.Position = 0;

            var bytes = stream.ToArray();

            return bytes;
        }

        /// <summary>
        /// Hàm định dạng dữ liệu khi xuất Excel
        /// </summary>
        /// <param name="worksheet">Trang tính</param>
        /// <param name="row">Vị trí hàng của ô</param>
        /// <param name="col">Vị trí cột của ô</param>
        /// <param name="value">Giá trị của ô</param>
        private void FormatData(ExcelWorksheet worksheet, int row, int col, object? value, string? align)
        {
            var horizontalAlign = ExcelHorizontalAlignment.Left;

            switch (align)
            {
                case "right":
                    horizontalAlign = ExcelHorizontalAlignment.Right;
                    break;
                case "center":
                    horizontalAlign = ExcelHorizontalAlignment.Center;
                    break;
                default:
                    break;
            }

            worksheet.Cells[row, col].Style.HorizontalAlignment = horizontalAlign;

            switch (value)
            {
                case DateTime:
                    worksheet.Cells[row, col].Value = ((DateTime)value).ToString("dd/MM/yyyy");
                    break;
                case Gender:
                    worksheet.Cells[row, col].Value = (Gender)value == Gender.Male ?
                        CommonResource.Male : (Gender)value == Gender.Female ? CommonResource.Female : CommonResource.Other;
                    break;
                default:
                    worksheet.Cells[row, col].Value = value;
                    break;
            }
        }

        /// <summary>
        /// Lấy dữ liệu về tên các cột trong file Excel
        /// và tên các thuộc tính của đối tượng cần map từ các cột đó
        /// </summary>
        /// <param name="excelGetMapDto">Thông tin của file Excel</param>
        /// <returns>
        /// Gồm hai danh sách:
        /// - Danh sách tên các cột trong file Excel và vị trí cột
        /// - Danh sách tên các thuộc tính của đối tượng
        /// </returns>
        /// CreatedBy: txphuc (29/07/2023)
        public ExcelMapResponseDto GetMapExcel(ExcelGetMapDto excelGetMapDto)
        {
            //var fileName = excelGetMapRequestDto.FileName;
            var fileName = "import" + ".xlsx";
            var filePath = Path.Combine(AppProvider.ContentRootPath, "StaticFile", "Excel", fileName);
            using var stream = new FileStream(filePath, FileMode.Open);

            //var headerRowIndex = excelGetMapRequestDto.HeaderRowIndex;
            var headerRowIndex = 8;
            var sheetIndex = excelGetMapDto.SheetIndex ?? 0;

            // Đọc file excel
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using var excelPackage = new ExcelPackage(stream);

            var worksheet = excelPackage.Workbook.Worksheets[sheetIndex];
            var colCount = worksheet.Dimension.Columns;

            // Đọc các cột tiêu đề trong file Excel
            List<ExcelColumnDto> excelColumns = new();

            for (var col = 1; col <= colCount; col++)
            {
                var headerName = worksheet.Cells[headerRowIndex, col].Value.ToString();

                var excelColumn = new ExcelColumnDto()
                {
                    ColumnName = headerName ?? "",
                    Index = col,
                };

                excelColumns.Add(excelColumn);
            }

            // Đọc các Property của đối tượng cần mapping với các cột Excel
            var properties = typeof(TEntityExcelInsertDto).GetProperties();
            List<MappingColumnDto> mappingColumns = new();
            foreach (var property in properties)
            {
                var mappingColumn = new MappingColumnDto()
                {
                    PropertyName = property.Name,
                    DisplayName = AttributeGetter.GetDisplayAttribute(property),
                };

                mappingColumns.Add(mappingColumn);
            }

            var excelMapResponseDto = new ExcelMapResponseDto()
            {
                ExcelColumns = excelColumns,
                MappingColumns = mappingColumns,
            };

            return excelMapResponseDto;
        }

        /// <summary>
        /// Đọc data từ file Excel và map sang đối tượng
        /// </summary>
        /// <param name="mapRequestDto">
        /// Chứa thông tin về file Excel và danh sách hướng dẫn map
        /// </param>
        /// <returns>Danh sách các đối tượng đã đọc từ file Excel</returns>
        public IEnumerable<TEntityExcelInsertDto> ReadExcelData(ExcelMapRequestDto mapRequestDto)
        {
            //var fileName = excelGetMapRequestDto.FileName;
            var fileName = "import" + ".xlsx";
            var filePath = Path.Combine(AppProvider.ContentRootPath, "StaticFile", "Excel", fileName);
            using var stream = new FileStream(filePath, FileMode.Open);

            //var headerRowIndex = excelGetMapRequestDto.HeaderRowIndex;
            var headerRowIndex = 8;
            var sheetIndex = mapRequestDto.SheetIndex ?? 0;

            // Đọc file excel
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using var excelPackage = new ExcelPackage(stream);

            var worksheet = excelPackage.Workbook.Worksheets[sheetIndex];
            var rowCount = worksheet.Dimension.Rows;

            // Lặp qua các dòng để lấy dữ liệu
            List<TEntityExcelInsertDto> employeeExcelInsertDtos = new();
            for (var row = headerRowIndex + 1; row <= rowCount; row++)
            {
                var employeeExcelInsertDto = GetEntityInsertDtoInstance();
                var type = typeof(TEntityExcelInsertDto);

                // Set giá trị cho đối tượng theo cấu hình đã được map
                if (mapRequestDto.MappingConfigColumns != null)
                {
                    foreach (var mappingConfigCol in mapRequestDto.MappingConfigColumns)
                    {
                        var property = type.GetProperty(mappingConfigCol.PropertyName);
                        if (property != null && property.CanWrite)
                        {
                            var value = worksheet.Cells[row, mappingConfigCol.MapIndex].Value;

                            property.SetValue(employeeExcelInsertDto, value);
                        }
                    }
                }

                employeeExcelInsertDtos.Add(employeeExcelInsertDto);
            }

            return employeeExcelInsertDtos;
        }

        /// <summary>
        /// Lấy instance của đối tượng để có thể gán giá trị cho đối tượng generic
        /// </summary>
        /// <returns>Instance của TEntityExcelInsertDto</returns>
        /// CreatedBy: txphuc (29/07/2023)
        protected abstract TEntityExcelInsertDto GetEntityInsertDtoInstance();
        #endregion
    }
}

using MISA.AmisMintax.Application;
using MISA.AmisMintax.Domain;
using MISA.AmisMintax.Domain.Resources.Common;
using MISA.AmisMintax.Domain.Resources.ErrorMessage;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Infrastructure
{
    public class ExcelCore : IExcelCore
    {
        #region Fields
        private ExcelPackage _excelPackage;
        #endregion

        #region Constructors
        protected ExcelCore()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            _excelPackage = new ExcelPackage();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thêm một trang tính mới
        /// </summary>
        /// <param name="entityDtos">Dữ liệu ghi ra trang tính</param>
        /// <param name="exportSheetDto">Cấu hình trang tính</param>
        /// CreatedBy: txphuc (28/08/2023)
        public void AddWorkSheet(IEnumerable<object> entityDtos, ExcelExportSheetDto exportSheetDto)
        {
            if (entityDtos.ToList().Count > 0
                && exportSheetDto != null
                && exportSheetDto.Columns.Count > 0)
            {
                // Định nghĩa một trang tính
                var worksheet = _excelPackage.Workbook.Worksheets.Add(exportSheetDto.SheetName);

                // Định nghĩa style chung
                var cellStyle = _excelPackage.Workbook.Styles.CreateNamedStyle("CellStyle" + exportSheetDto.SheetKey);
                cellStyle.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                cellStyle.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                cellStyle.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                cellStyle.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                cellStyle.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                cellStyle.Style.Font.Name = "Times New Roman";
                cellStyle.Style.Font.Size = 12;
                cellStyle.Style.WrapText = true;

                // Tổng số cột
                var totalColumns = exportSheetDto.Columns.Count;

                // Tạo kiểu cho tiêu đề trang tính
                worksheet.Cells["A1"].Value = exportSheetDto?.SheetTitle?.ToUpper() ?? "";
                using var titleRange = worksheet.Cells[1, 1, 1, totalColumns];
                titleRange.Merge = true;
                titleRange.Style.Font.Size = 16;
                titleRange.Style.Font.Name = "Times New Roman";
                titleRange.Style.Font.Bold = true;
                titleRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                titleRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                titleRange.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#FFBA86"));
                titleRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Rows[1].Height = 22;


                // Ghi các nhóm cột ra file Excel
                var colGroupRowIndex = 2;
                foreach (var colGroup in exportSheetDto.ColumnGroups)
                {
                    worksheet.Cells[colGroupRowIndex, colGroup.StartColumn].Value = colGroup.Title.ToUpper();

                    using var colGroupRange = worksheet.Cells[colGroupRowIndex, colGroup.StartColumn, colGroupRowIndex, colGroup.EndColumn];
                    colGroupRange.Merge = true;
                    colGroupRange.StyleName = cellStyle.Name;
                    colGroupRange.Style.Font.Bold = true;
                    colGroupRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    colGroupRange.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(colGroup.Background ?? "#BEF2FF"));
                    colGroupRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }



                // Ghi tên cột ra file Excel
                var headerRowIndex = 3;
                var properties = entityDtos.ToList()[0].GetType().GetProperties();
                worksheet.Rows[headerRowIndex].Height = 36;

                foreach (var property in properties)
                {
                    // Tìm thông tin cột tương ứng với tên thuộc tính
                    var column = exportSheetDto.Columns.FirstOrDefault(col => col.DataField.ToLower() == property.Name.ToLower());

                    if (column != null)
                    {
                        // Set title và màu sắc cho từng cột
                        var headerCell = worksheet.Cells[headerRowIndex, column.Index];
                        headerCell.Value = column.Caption;

                        headerCell.StyleName = cellStyle.Name;
                        headerCell.Style.Font.Size = column.FontSize ?? 12;
                        headerCell.Style.Font.Bold = true;
                        headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        headerCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        headerCell.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(column.HeaderBackground ?? "#FFBA86"));

                        // Chuyển đổi từ px sang đơn vị Excel
                        var collumnWidth = column.Width / 7.5;
                        worksheet.Columns[column.Index].Width = collumnWidth != null ? collumnWidth.Value : 150 / 7.5;
                    }
                }


                // Ghi nội dung
                var currentRow = 4;
                foreach (var entityDto in entityDtos)
                {
                    // Tạo kiểu cho các ô và các hàng
                    worksheet.Cells[currentRow, 1, currentRow, totalColumns].StyleName = cellStyle.Name;
                    worksheet.Rows[currentRow].Height = 28;

                    foreach (var property in properties)
                    {
                        // Tìm thông tin cột tương ứng với tên thuộc tính
                        var column = exportSheetDto.Columns.FirstOrDefault(col => col.DataField.ToLower() == property.Name.ToLower());

                        // Gán giá trị cho ô
                        if (column != null)
                        {
                            var value = property.GetValue(entityDto);

                            FormatData(worksheet, currentRow, column.Index, value, column.Alignment, column.Format);
                        }
                    }

                    currentRow++;
                }
            }
        }

        /// <summary>
        /// Lấy mảng bytes của file Excel để download 
        /// (bao gồm tất cả trang tính đã thêm)
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (28/08/2023)
        public byte[] GetExcelBytes()
        {
            // Tạo luồng download file
            using var stream = new MemoryStream();

            // Lưu file Excel
            _excelPackage.SaveAs(stream);

            return stream.ToArray();
        }

        /// <summary>
        /// Định dạng dữ liệu khi xuất Excel
        /// </summary>
        /// <param name="worksheet">Trang tính</param>
        /// <param name="row">Vị trí hàng của ô</param>
        /// <param name="col">Vị trí cột của ô</param>
        /// <param name="value">Giá trị của ô</param>
        private void FormatData(ExcelWorksheet worksheet, int row, int col, object? value, string? align, string? format = null)
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
                    if (format != null)
                    {
                        worksheet.Cells[row, col].Value = ((DateTime)value).ToString(format);
                    }
                    else
                    {
                        worksheet.Cells[row, col].Value = ((DateTime)value).ToString("dd/MM/yyyy");
                    }
                    break;
                case bool:
                    worksheet.Cells[row, col].Value = (bool)value ? 1: 0;
                    break;
                default:
                    worksheet.Cells[row, col].Value = value;
                    break;
            }
        }
        #endregion
    }
}

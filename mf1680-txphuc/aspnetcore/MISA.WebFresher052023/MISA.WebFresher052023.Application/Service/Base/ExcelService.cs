using AutoMapper;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.Common;
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

namespace MISA.WebFresher052023.Application
{
    public abstract class ExcelService<TEntity, TModel, TEntityDto> : IExcelService
    {
        private readonly IBaseReadOnlyRepository<TEntity, TModel> _baseReadOnlyRepository;
        private readonly IMapper _mapper;

        protected virtual string SheetName { get; set; } = "Sheet 1";
        protected virtual string SheetTitle { get; set; } = "Sheet title";

        protected ExcelService(IBaseReadOnlyRepository<TEntity, TModel> baseReadOnlyRepository, IMapper mapper)
        {
            _baseReadOnlyRepository = baseReadOnlyRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Xử lý xuất file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (23/07/2023)
        public async Task<byte[]> ExportToExcelAsync()
        {

            // Lấy danh sách đối tượng
            var entity = await _baseReadOnlyRepository.GetAllAsync();
            var entityDtos = _mapper.Map<IEnumerable<TEntityDto>>(entity);

            // Tạo luồng download file
            var stream = new MemoryStream();

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
            var properties = typeof(TEntityDto).GetProperties();
            var bonusOrderCol = 1;
            var totalColumns = properties.Length + bonusOrderCol;

            // Tạo kiểu cho tiêu đề
            worksheet.Cells["A1"].Value = SheetTitle;
            using var titleRange = worksheet.Cells[1, 1, 1, totalColumns];
            titleRange.Merge = true;
            titleRange.Style.Font.Size = 16;
            titleRange.Style.Font.Name = "Arial";
            titleRange.Style.Font.Bold = true;
            titleRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            titleRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Rows[1].Height = 28;

            // Tên các cột
            var headerRow = 3;
            var colPos = 2;
            worksheet.Cells[headerRow, 1].Value = CommonResource.Order;

            foreach (var property in properties)
            {
                worksheet.Cells[headerRow, colPos].Value = GetDisplayName(property);

                colPos++;
            }

            // Style cho tên cột
            using var columnNameRange = worksheet.Cells[headerRow, 1, headerRow, totalColumns];
            columnNameRange.StyleName = cellStyle.Name;
            columnNameRange.Style.Font.Bold = true;
            columnNameRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            columnNameRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
            columnNameRange.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            worksheet.Rows[headerRow].Height = 28;

            // Nội dung
            var currentRow = 4;
            var order = 1;
            foreach (var entityDto in entityDtos)
            {
                var currentCol = 2;
                worksheet.Cells[currentRow, 1].Value = order;

                foreach (var property in properties)
                {
                    worksheet.Cells[currentRow, currentCol].Value = property.GetValue(entityDto);

                    currentCol++;
                }

                // Tạo kiểu cho các ô và các hàng
                worksheet.Cells[currentRow, 1, currentRow, totalColumns].StyleName = cellStyle.Name;
                worksheet.Cells.AutoFitColumns();
                worksheet.Rows[currentRow].Height = 28;

                currentRow++;
                order++;
            }

            excelPackage.Save();

            stream.Position = 0;

            var bytes = stream.ToArray();

            return bytes;
        }

        /// <summary>
        /// Xử lý nhập file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (23/07/2023)
        public async Task ImportExcelAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy ra thuộc tính DisplayName của Property để hiển thị
        /// </summary>
        /// <param name="property">Property</param>
        /// <returns>Tên hiển thị</returns>
        /// CreatedBy: txphuc (23/07/2023)
        private string GetAttributeDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);

            if (atts.Length > 0)
            {
                // Ép kiểu phần tử đầu tiên về DisplayNameAttribute
                //var displayNameAttribute = atts.FirstOrDefault() as DisplayNameAttribute;
                if (atts.FirstOrDefault() is DisplayNameAttribute displayNameAttribute)
                {

                    return displayNameAttribute.DisplayName;
                }
                else
                {
                    return property.Name;
                }
            }

            return property.Name;
        }

        /// <summary>
        /// Lấy ra thuộc tính Display của Property để hiển thị đa ngôn ngữ
        /// </summary>
        /// <param name="property">Property</param>
        /// <returns>Tên hiển thị theo ngôn ngữ</returns>
        /// CreatedBy: txphuc (23/07/2023)
        private string GetDisplayName(PropertyInfo property)
        {
            var atts = property.GetCustomAttributes(typeof(DisplayAttribute), true);

            if (atts.Length > 0)
            {
                // Ép kiểu phần tử đầu tiên về DisplayAttribute
                if (atts.FirstOrDefault() is DisplayAttribute displayNameAttribute)
                {
                    // Lấy ra giá trị của Name
                    var displayName = displayNameAttribute.GetName();

                    if (displayName != null)
                    {
                        return displayName;
                    }
                }
            }

            return property.Name;
        }
    }
}

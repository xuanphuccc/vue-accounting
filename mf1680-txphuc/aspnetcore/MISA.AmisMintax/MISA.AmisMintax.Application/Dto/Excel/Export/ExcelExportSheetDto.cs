using MISA.AmisMintax.Domain.Resources.InputValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelExportSheetDto
    {
        /// <summary>
        /// Tên của trang tính
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public string SheetName { get; set; } = "Sheet" + Guid.NewGuid().ToString();

        /// <summary>
        /// Tiêu đề hiển thị trên trang tính
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        public string? SheetTitle { get; set; } = string.Empty;

        /// <summary>
        /// Khoá tương ứng với tên bảng trong database
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public string SheetKey { get; set; } = string.Empty;

        /// <summary>
        /// Danh sách cấu hình nhóm cột
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        public List<ExcelExportColumnGroupDto>? ColumnGroups { get; set; } = new List<ExcelExportColumnGroupDto>();

        /// <summary>
        /// Danh sách cấu hình các cột
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        public List<ExcelExportColumnDto>? Columns { get; set; } = new List<ExcelExportColumnDto>();
    }
}

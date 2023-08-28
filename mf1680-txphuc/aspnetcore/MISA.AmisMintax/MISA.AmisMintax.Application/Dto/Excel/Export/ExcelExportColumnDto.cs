using MISA.AmisMintax.Domain.Resources.InputValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelExportColumnDto
    {
        /// <summary>
        /// Tên thuộc tính muốn ghi ra Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public string DataField { get; set; } =  string.Empty;

        /// <summary>
        /// Tên cột hiển thị trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public string Caption { get; set;} = string.Empty;

        /// <summary>
        /// Vị trí cột trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public int Index { get; set; }

        /// <summary>
        /// Độ rộng của cột
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public double Width { get; set; } = 150;

        /// <summary>
        /// Căn lề của dữ liệu
        /// </summary>
        /// CreatedBy: txphuc (31/07/2023)
        public string? Alignment { get; set; } = "left";

        /// <summary>
        /// Font chữ
        /// </summary>
        /// CreatedBy: txphuc (29/08/2023)
        public float? FontSize { get; set; } = 12;

        /// <summary>
        /// Màu sắc cột header
        /// </summary>
        public string? HeaderBackground { get; set;} = "#BEF2FF";
    }
}

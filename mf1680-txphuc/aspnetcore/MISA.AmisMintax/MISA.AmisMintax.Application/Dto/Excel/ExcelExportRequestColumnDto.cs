using MISA.AmisMintax.Domain.Resources.InputValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelExportRequestColumnDto
    {
        /// <summary>
        /// Tên thuộc tính muốn ghi ra Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public string DataIndex { get; set; } = string.Empty;

        /// <summary>
        /// Tên cột hiển thị trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public string Title { get; set;} = string.Empty;

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
        public double Width { get; set; } = 140;

        /// <summary>
        /// Căn lề của dữ liệu
        /// </summary>
        /// CreatedBy: txphuc (31/07/2023)
        public string? Align { get; set; } = "left";
    }
}

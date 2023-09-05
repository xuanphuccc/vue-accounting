using MISA.AmisMintax.Domain.Resources.InputValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelExportColumnGroupDto
    {
        /// <summary>
        /// Tiêu đề của nhóm cột
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Vị trí bắt đầu của nhóm cột
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public int StartColumn { get; set; }

        /// <summary>
        /// Vị trí kết thúc của nhóm cột
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public int EndColumn { get; set; }

        /// <summary>
        /// Background hiển thị
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        public string? Background { get; set; } = "#BEF2FF";
    }
}

using MISA.AmisMintax.Domain.Resources.InputValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelExportRequestDto
    {
        /// <summary>
        /// Danh sách Id của các bản ghi muốn xuất Excel
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public List<Guid> EntityIds { get; set; } = new List<Guid>();

        /// <summary>
        /// Danh sách cấu hình Sheet muốn xuất ra Excel
        /// </summary>
        /// CreatedBy: txphuc (28/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public List<ExcelExportSheetDto> ExcelExportSheets { get; set; } = new List<ExcelExportSheetDto>();
    }
}

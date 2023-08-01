using MISA.WebFresher052023.Domain.Resources.InputValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class ExcelExportRequestDto
    {
        /// <summary>
        /// Danh sách Id của các bản ghi muốn xuất Excel
        /// </summary>
        /// CreatedBy: txphuc (26/07/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public List<Guid> EntityIds { get; set; } = new List<Guid>();

        /// <summary>
        /// Danh sách cột muốn export ra Excel
        /// </summary>
        /// CreatedBy: txphuc (26/07/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public List<ExcelColumnDto> Columns { get; set; } = new List<ExcelColumnDto>();
    }
}

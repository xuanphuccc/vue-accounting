using Microsoft.Extensions.Localization;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class DepartmentCreateDto
    {
        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessage = "Mã đơn vị không được để trống")]
        [StringLength(20, ErrorMessage = "Mã đơn vị tối đa 20 ký tự")]
        [RegularExpression(@"[a-zA-Z]{1,}-[0-9]{4,}", ErrorMessage = "Mã đơn vị phải có định dạng xx-xxxx trong đó sau xx- có ít nhất 4 số")]
        public string DepartmentCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessage = "Tên đơn vị không được để trống")]
        [StringLength(255, ErrorMessage = "Tên đơn vị tối đa 255 ký tự")]
        public string DepartmentName { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessage = "Mô tả tối đa 255 ký tự")]
        public string? Description { get; set; }
    }
}

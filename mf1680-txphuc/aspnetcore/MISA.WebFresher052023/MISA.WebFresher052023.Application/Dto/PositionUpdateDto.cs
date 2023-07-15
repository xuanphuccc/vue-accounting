using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class PositionUpdateDto
    {
        /// <summary>
        /// Mã vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessage = "Mã vị trí không được để trống")]
        [StringLength(20, ErrorMessage = "Mã vị trí tối đa 20 ký tự")]
        [RegularExpression(@"^VT-[0-9]{4,}$", ErrorMessage = "Mã vị trí phải có định dạng NV-XXXX trong đó sau VT có ít nhất 4 số")]
        public string PositionCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessage = "Tên vị trí không được để trống")]
        [StringLength(255, ErrorMessage = "Tên vị trí tối đa 255 ký tự")]
        public string PositionName { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessage = "Mô tả tối đa 255 ký tự")]
        public string? Description { get; set; }
    }
}

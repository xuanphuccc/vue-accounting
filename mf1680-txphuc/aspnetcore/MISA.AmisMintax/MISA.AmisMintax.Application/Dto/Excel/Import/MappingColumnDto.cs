using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class MappingColumnDto
    {
        /// <summary>
        /// Tên thuộc tính cần lấy dữ liệu
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public string PropertyName { get; set; } = string.Empty;

        /// <summary>
        /// Tên hiển thị của thuộc tính
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public string DisplayName { get; set; } = string.Empty;
    }
}

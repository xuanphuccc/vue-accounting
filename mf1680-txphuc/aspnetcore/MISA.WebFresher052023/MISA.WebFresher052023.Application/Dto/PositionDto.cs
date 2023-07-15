using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class PositionDto
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(20)]
        public string PositionCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(255)]
        public string PositionName { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255)]
        public string? Description { get; set; }
    }
}

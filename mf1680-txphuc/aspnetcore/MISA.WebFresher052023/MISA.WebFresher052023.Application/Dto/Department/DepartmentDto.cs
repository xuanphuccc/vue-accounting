using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class DepartmentDto
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(20)]
        public string DepartmentCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(255)]
        public string DepartmentName { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255)]
        public string? Description { get; set; }
    }
}

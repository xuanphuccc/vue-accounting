using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class ExcelColumnDto
    {
        /// <summary>
        /// Tên cột tiêu đề trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public string ColumnName { get; set; } = string.Empty;

        /// <summary>
        /// Vị trí cột trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public int Index { get; set; }

        /// <summary>
        /// Căn lề của dữ liệu
        /// </summary>
        /// CreatedBy: txphuc (31/07/2023)
        public string? Align { get; set; } = "left";
    }
}

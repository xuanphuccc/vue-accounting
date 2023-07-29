using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class ExcelMapResponseDto
    {
        /// <summary>
        /// Danh sách cột tiêu đề trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public List<ExcelColumnDto>? ExcelColumns { get; set; }

        /// <summary>
        /// Danh sách thuộc tính cần mapping dữ liệu
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public List<MappingColumnDto>? MappingColumns { get; set; }
    }

    public class ExcelColumnDto
    {
        /// <summary>
        /// Tên cột tiêu đề trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public string ColumnName { get; set; } = string.Empty;

        /// <summary>
        /// Vị trí cột tiêu đề trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public int Index { get; set; }
    }

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
        public string DisplayName { get; set;} = string.Empty;
    }
}

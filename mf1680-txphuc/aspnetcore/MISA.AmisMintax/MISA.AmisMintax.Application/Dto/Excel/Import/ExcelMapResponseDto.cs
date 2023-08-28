using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
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
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelGetMapDto
    {
        /// <summary>
        /// File Excel muốn lấy map
        /// </summary>
        /// CreatedBy: txphuc (28/07/2023)
        [Required]
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Vị trí dòng tiêu đề
        /// </summary>
        /// CreatedBy: txphuc (28/07/2023)
        [Required]
        public int HeaderRowIndex { get; set; }

        /// <summary>
        /// Vị trí trang tính
        /// </summary>
        /// CreatedBy: txphuc (28/07/2023)
        public int? SheetIndex { get; set; }
    }
}

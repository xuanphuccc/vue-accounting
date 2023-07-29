using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class ExcelMapRequestDto
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

        [Required]
        public List<MappingConfigColumnDto>? MappingConfigColumns { get; set; }
    }

    public class MappingConfigColumnDto
    {
        /// <summary>
        /// Tên trường dữ liệu
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public string PropertyName { get; set; } = string.Empty;

        /// <summary>
        /// Thứ tự cột dữ liệu cần lấy trong file Excel
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public int MapIndex { get; set; }

        /// <summary>
        /// Là thuộc tính có dữ liệu trong file Excel hay không
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        [Required]
        public bool Show { get; set; }
    }
}

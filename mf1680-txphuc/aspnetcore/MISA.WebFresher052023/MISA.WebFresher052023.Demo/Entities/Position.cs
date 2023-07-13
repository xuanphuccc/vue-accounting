using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Entities
{
    public class Position
    {
        // Khoá chính
        [Required]
        public Guid PositionId { get; set; }

        // Mã vị trí
        [Required]
        [StringLength(20)]
        public string PositionCode { get; set; } = string.Empty;

        // Tên vị trí
        [Required]
        [StringLength(255)]
        public string PositionName { get; set; } = string.Empty;

        // Mô tả
        [StringLength(255)]
        public string? Description { get; set; }

        // Ngày tạo
        public DateTime? CreatedDate { get; set; }

        // Người tạo
        [StringLength(255)]
        public string? CreatedBy { get; set; }

        // Ngày sửa
        public DateTime? ModifiedDate { get; set; }

        // Người sửa
        [StringLength(255)]
        public string? ModifiedBy { get; set; }
    }
}

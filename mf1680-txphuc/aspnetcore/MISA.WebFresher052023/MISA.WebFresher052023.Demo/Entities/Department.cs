using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Entities
{
    public class Department
    {
        // Khoá chính
        [Required]
        public Guid DepartmentId { get; set; }

        // Mã đơn vị
        [Required]
        [StringLength(20)]
        public string DepartmentCode { get; set; } = string.Empty;

        // Tên đơn vị
        [Required]
        [StringLength(255)]
        public string DepartmentName { get; set; } = string.Empty;

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

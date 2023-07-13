using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Entities
{
    public class Department
    {
        [Required]
        public Guid DepartmentId { get; set; }

        [Required]
        [StringLength(20)]
        public string DepartmentCode { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string DepartmentName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(255)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string? ModifiedBy { get; set; }
    }
}

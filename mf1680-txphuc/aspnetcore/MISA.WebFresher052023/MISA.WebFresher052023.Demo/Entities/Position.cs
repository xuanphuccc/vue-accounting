using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Entities
{
    public class Position
    {
        [Required]
        public Guid PositionId { get; set; }

        [Required]
        [StringLength(20)]
        public string PositionCode { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string PositionName { get; set; } = string.Empty;

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

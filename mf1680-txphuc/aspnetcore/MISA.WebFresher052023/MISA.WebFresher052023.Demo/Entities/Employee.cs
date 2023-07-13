using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Entities
{
    public class Employee
    {
        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public int? Gender { get; set; }

        [StringLength(25)]
        public string? IdentityNumber { get; set; }

        public DateTime? IdentityDate { get; set; }

        [StringLength(255)]
        public string? IdentityPlace { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? MobilePhoneNumber { get; set; }

        [StringLength(50)]
        public string? LandlineNumber { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(25)]
        public string? BankAccount { get; set; }

        [StringLength(255)]
        public string? BankName { get; set; }

        [StringLength(255)]
        public string? BankBranch { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(255)]
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string? ModifiedBy { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [StringLength(36)]
        public Guid? PositionId { get; set; }
    }
}

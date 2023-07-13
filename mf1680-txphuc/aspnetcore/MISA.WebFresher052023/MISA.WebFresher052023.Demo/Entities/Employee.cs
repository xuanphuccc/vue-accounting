using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Entities
{
    public class Employee
    {
        // Khoá chính
        [Required]
        public Guid EmployeeId { get; set; }

        // Mã nhân viên
        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; } = string.Empty;

        // Tên nhân viên
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        // Ngày sinh
        public DateTime? DateOfBirth { get; set; }

        // Giới tính (0 - nữ, 1 - nam, 2 - khác)
        public int? Gender { get; set; }

        // Số Chứng minh nhân dân
        [StringLength(25)]
        public string? IdentityNumber { get; set; }

        // Ngày cấp Chứng minh nhân dân
        public DateTime? IdentityDate { get; set; }

        // Nơi cấp Chứng minh nhân dân
        [StringLength(255)]
        public string? IdentityPlace { get; set; }

        // Địa chỉ
        [StringLength(255)]
        public string? Address { get; set; }

        // Số điện thoại di động
        [StringLength(50)]
        public string? MobilePhoneNumber { get; set; }

        // Số điện thoại cố định
        [StringLength(50)]
        public string? LandlineNumber { get; set; }

        // Email
        [StringLength(100)]
        public string? Email { get; set; }

        // Tài khoản ngân hàng
        [StringLength(25)]
        public string? BankAccount { get; set; }

        // Tên ngân hàng
        [StringLength(255)]
        public string? BankName { get; set; }

        // Chi nhánh ngân hàng
        [StringLength(255)]
        public string? BankBranch { get; set; }

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

        // Mã đơn vị (khoá ngoại)
        [Required]
        public Guid DepartmentId { get; set; }

        // Mã vị trí (khoá ngoại)
        [StringLength(36)]
        public Guid? PositionId { get; set; }
    }
}

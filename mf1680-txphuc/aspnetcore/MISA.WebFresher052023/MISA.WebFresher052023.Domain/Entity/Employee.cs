using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Domain
{
    public class Employee : BaseAuditEntity, IHasKey
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0 - nam, 1 - nữ, 2 - khác)
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        public Gender? Gender { get; set; }

        /// <summary>
        /// Số Chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(25)]
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp Chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp Chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255)]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255)]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(50)]
        public string? MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(50)]
        public string? LandlineNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(25)]
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255)]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255)]
        public string? BankBranch { get; set; }

        /// <summary>
        /// Mã đơn vị (khoá ngoại)
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã vị trí (khoá ngoại)
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(36)]
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Lấy Id của đối tượng
        /// </summary>
        /// <returns>Id của đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public Guid GetKey()
        {
            return EmployeeId;
        }
    }
}

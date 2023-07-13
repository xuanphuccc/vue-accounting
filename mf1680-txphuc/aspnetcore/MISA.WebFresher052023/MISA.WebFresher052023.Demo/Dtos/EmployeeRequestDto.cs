using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Dtos
{
    public class EmployeeRequestDto
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required(ErrorMessage = "Mã không được để trống")]
        [StringLength(20, ErrorMessage = "Mã tối đa 20 ký tự")]
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự")]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Số Chứng minh nhân dân
        /// </summary>
        [StringLength(25, ErrorMessage = "Số CCCD tối đa 25 ký tự")]
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp Chứng minh nhân dân
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp Chứng minh nhân dân
        /// </summary>
        [StringLength(255, ErrorMessage = "Nơi cấp tối đa 255 ký tự")]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [StringLength(255, ErrorMessage = "Địa chỉ tối đa 255 ký tự")]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        [StringLength(50, ErrorMessage = "Số điện thoại di động tối đa 50 ký tự")]
        public string? MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        [StringLength(50, ErrorMessage = "Số điện thoại cố định tối đa 50 ký tự")]
        public string? LandlineNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(100, ErrorMessage = "Email tối đa 100 ký tự")]
        public string? Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        [StringLength(25, ErrorMessage = "Tài khoản ngân hàng tối đa 25 ký tự")]
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [StringLength(255, ErrorMessage = $"Tên ngân hàng tối đa 255 ký tự")]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        [StringLength(255, ErrorMessage = $"Chi nhánh tối đa 255 ký tự")]
        public string? BankBranch { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        [Required(ErrorMessage = "Mã đơn vị không được để trống")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        [StringLength(36)]
        public Guid? PositionId { get; set; }
    }
}

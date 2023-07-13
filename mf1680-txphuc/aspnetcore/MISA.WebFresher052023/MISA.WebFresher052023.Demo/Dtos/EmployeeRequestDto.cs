using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Demo.Dtos
{
    public class EmployeeRequestDto
    {
        [Required(ErrorMessage = "Mã không được để trống")]
        [StringLength(20, ErrorMessage = "Mã tối đa 20 ký tự")]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự")]
        public string FullName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public int? Gender { get; set; }

        [StringLength(25, ErrorMessage = "Số CCCD tối đa 25 ký tự")]
        public string? IdentityNumber { get; set; }

        public DateTime? IdentityDate { get; set; }

        [StringLength(255, ErrorMessage = "Nơi cấp tối đa 255 ký tự")]
        public string? IdentityPlace { get; set; }

        [StringLength(255, ErrorMessage = "Địa chỉ tối đa 255 ký tự")]
        public string? Address { get; set; }

        [StringLength(50, ErrorMessage = "Số điện thoại di động tối đa 50 ký tự")]
        public string? MobilePhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Số điện thoại cố định tối đa 50 ký tự")]
        public string? LandlineNumber { get; set; }

        [StringLength(100, ErrorMessage = "Email tối đa 100 ký tự")]
        public string? Email { get; set; }

        [StringLength(25, ErrorMessage = "Tài khoản ngân hàng tối đa 25 ký tự")]
        public string? BankAccount { get; set; }

        [StringLength(255, ErrorMessage = $"Tên ngân hàng tối đa 255 ký tự")]
        public string? BankName { get; set; }

        [StringLength(255, ErrorMessage = $"Chi nhánh tối đa 255 ký tự")]
        public string? BankBranch { get; set; }

        [Required(ErrorMessage = "Mã đơn vị không được để trống")]
        public Guid DepartmentId { get; set; }

        [StringLength(36)]
        public Guid? PositionId { get; set; }
    }
}

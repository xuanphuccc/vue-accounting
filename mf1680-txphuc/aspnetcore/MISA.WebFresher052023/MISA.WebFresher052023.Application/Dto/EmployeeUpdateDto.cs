using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class EmployeeUpdateDto
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessage = "Mã không được để trống")]
        [StringLength(20, ErrorMessage = "Mã tối đa 20 ký tự")]
        [RegularExpression(@"^NV-[0-9]{4,}$", ErrorMessage = "Mã nhân viên phải có định dạng NV-0000 trong đó sau NV có ít nhất 4 số")]
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự")]
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
        [StringLength(25, ErrorMessage = "Số CCCD tối đa 25 ký tự")]
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
        [StringLength(255, ErrorMessage = "Nơi cấp tối đa 255 ký tự")]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessage = "Địa chỉ tối đa 255 ký tự")]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(50, ErrorMessage = "Số điện thoại di động tối đa 50 ký tự")]
        public string? MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(50, ErrorMessage = "Số điện thoại cố định tối đa 50 ký tự")]
        public string? LandlineNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(100, ErrorMessage = "Email tối đa 100 ký tự")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không đúng định dạng")]
        public string? Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(25, ErrorMessage = "Tài khoản ngân hàng tối đa 25 ký tự")]
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessage = $"Tên ngân hàng tối đa 255 ký tự")]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessage = $"Chi nhánh tối đa 255 ký tự")]
        public string? BankBranch { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessage = "Mã đơn vị không được để trống")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(36, ErrorMessage = "Id tối đa 36 ký tự")]
        public Guid? PositionId { get; set; }
    }
}

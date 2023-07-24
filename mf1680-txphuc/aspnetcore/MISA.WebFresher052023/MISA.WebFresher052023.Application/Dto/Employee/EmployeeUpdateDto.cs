using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.InputValidation;
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
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        [RegularExpression(@"[a-zA-Z]{1,}-[0-9]{4,}", ErrorMessageResourceName = nameof(InputValidation.CodeFormat), ErrorMessageResourceType = typeof(InputValidation))]
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        [StringLength(100, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
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
        [StringLength(25, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
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
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Là khách hàng
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        public bool? IsCustomer { get; set; }

        /// <summary>
        /// Là nhà cung cấp
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        public bool? IsSupplier { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(50, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(50, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? LandlineNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(100, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessageResourceName = nameof(InputValidation.IncorrectFormat), ErrorMessageResourceType = typeof(InputValidation))]
        public string? Email { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(25, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? BankBranch { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        public Guid? PositionId { get; set; }
    }
}

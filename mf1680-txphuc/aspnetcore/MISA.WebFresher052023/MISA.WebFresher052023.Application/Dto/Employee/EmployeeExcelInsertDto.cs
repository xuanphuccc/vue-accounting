﻿using MISA.WebFresher052023.Domain.Resources.Employee;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MISA.WebFresher052023.Domain.Resources.InputValidation;

namespace MISA.WebFresher052023.Application
{
    public class EmployeeExcelInsertDto
    {
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.EmployeeCode), ResourceType = typeof(EmployeeResource))]
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.FullName), ResourceType = typeof(EmployeeResource))]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.DepartmentCode), ResourceType = typeof(EmployeeResource))]
        public string DepartmentCode { get; set; } = string.Empty;

        /// <summary>
        /// Id của đơn vị
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.DateOfBirth), ResourceType = typeof(EmployeeResource))]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0 - nam, 1 - nữ, 2 - khác)
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.Gender), ResourceType = typeof(EmployeeResource))]
        public Gender? Gender { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.PositionName), ResourceType = typeof(EmployeeResource))]
        public string? PositionName { get; set; }

        /// <summary>
        /// Id của vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        public Guid PositionId { get; set; }

        /// <summary>
        /// Số Chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.IdentityNumber), ResourceType = typeof(EmployeeResource))]
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp Chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.IdentityDate), ResourceType = typeof(EmployeeResource))]
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp Chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.IdentityPlace), ResourceType = typeof(EmployeeResource))]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Là khách hàng
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [Display(Name = nameof(EmployeeResource.IsCustomer), ResourceType = typeof(EmployeeResource))]
        public bool? IsCustomer { get; set; }

        /// <summary>
        /// Là nhà cung cấp
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [Display(Name = nameof(EmployeeResource.IsSupplier), ResourceType = typeof(EmployeeResource))]
        public bool? IsSupplier { get; set; }

        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.BankAccount), ResourceType = typeof(EmployeeResource))]
        public string? BankAccount { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.BankName), ResourceType = typeof(EmployeeResource))]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.BankBranch), ResourceType = typeof(EmployeeResource))]
        public string? BankBranch { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.Address), ResourceType = typeof(EmployeeResource))]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.MobilePhoneNumber), ResourceType = typeof(EmployeeResource))]
        public string? MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.LandlineNumber), ResourceType = typeof(EmployeeResource))]
        public string? LandlineNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Display(Name = nameof(EmployeeResource.Email), ResourceType = typeof(EmployeeResource))]
        public string? Email { get; set; }

        /// <summary>
        /// Tình trạng validate
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        public bool IsValid { get; set; }

        /// <summary>
        /// Mã lỗi validate
        /// </summary>
        /// CreatedBy: txphuc (29/07/2023)
        public List<ErrorCode>? ErrorCodes { get; set; }
    }
}

using MISA.AmisMintax.Domain.Resources.InputValidation;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class EmployeeRelationshipUpdateDto
    {
        /// <summary>
        /// Họ tên thành viên
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        [StringLength(100, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Mã Quan hệ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public int Relationship { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Mã giới tính (0 - nam, 1 - nữ, 2 - khác)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public Gender? Gender { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(25, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? TaxCode { get; set; }

        /// <summary>
        /// Mã quốc tịch
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NationalityCode { get; set; }

        /// <summary>
        /// Mã loại giấy tờ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public IdentifyType? IdentifyKindOfPaper { get; set; }

        /// <summary>
        /// Số chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(25, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? IdentifyPaperNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? IdentifyNumberIssuedDate { get; set; }

        /// <summary>
        /// Mã nơi cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? IdentifyNumberIssuedPlaceCode { get; set; }


        // THÔNG TIN KHAI SINH
        /// <summary>
        /// Số khai sinh
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(25, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? DependentNumber { get; set; }

        /// <summary>
        /// Quyển số
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NumberBook { get; set; }

        /// <summary>
        /// Ngày cấp giấy khai sinh
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? BirthCertificationIssueDate { get; set; }

        /// <summary>
        /// Mã quốc gia
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? CountryCode { get; set; }

        /// <summary>
        /// Mã tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? ProvinceCode { get; set; }

        /// <summary>
        /// Mã quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? DistrictCode { get; set; }

        /// <summary>
        /// Mã xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? WardCode { get; set; }


        // HỘ KHẨU THƯỜNG TRÚ
        /// <summary>
        /// Mã tỉnh/thành phố (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyPermanentAddressProvinceCode { get; set; }

        /// <summary>
        /// Mã quận/huyện (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyPermanentAddressDistrictCode { get; set; }

        /// <summary>
        /// Mã xã/phường (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyPermanentAddressWardCode { get; set; }

        /// <summary>
        /// Số nhà, đường/phố, thôn/xóm (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyPermanentAddressStreetHouseNumber { get; set; }


        // CHỖ Ở HIỆN NAY
        /// <summary>
        /// Mã tỉnh/thành phố (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyCurrentProvinceCode { get; set; }

        /// <summary>
        /// Mã quận/huyện (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyCurrentDistrictCode { get; set; }

        /// <summary>
        /// Mã xã/phường (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyCurrentWardCode { get; set; }

        /// <summary>
        /// Số nhà, đường/phố, thôn/xóm (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyCurrentStreetHouseNumber { get; set; }


        // THÔNG TIN GIẢM TRỪ
        /// <summary>
        /// Là người phụ thuộc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public bool? IsDependent { get; set; }

        /// <summary>
        /// Giảm trừ từ tháng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? DeductionStartDate { get; set; }

        /// <summary>
        /// Giảm trừ đến tháng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? DeductionEndDate { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? Description { get; set; }

        /// <summary>
        /// Trạng thái sửa đổi
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public bool IsModified { get; set; }
    }
}

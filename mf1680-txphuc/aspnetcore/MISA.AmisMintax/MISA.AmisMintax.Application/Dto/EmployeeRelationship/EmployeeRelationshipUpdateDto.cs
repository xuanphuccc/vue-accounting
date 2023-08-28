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
        /// Khoá chính
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public Guid EmployeeRelationshipID { get; set; }

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
        /// Tên quan hệ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? RelationshipName { get; set; }

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
        /// Tên giới tính
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? GenderName { get; set; }

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
        /// Tên quốc tịch
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? NationalityName { get; set; }

        /// <summary>
        /// Mã loại giấy tờ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public IdentifyType? IdentifyKindOfPaper { get; set; }

        /// <summary>
        /// Tên loại giấy tờ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? IdentifyKindOfPaperName { get; set; }

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

        /// <summary>
        /// Tên nơi cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? IdentifyNumberIssuedPlaceName { get; set; }

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
        /// Tên quốc gia
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? CountryName { get; set; }

        /// <summary>
        /// Mã tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? ProvinceCode { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? ProvinceName { get; set; }

        /// <summary>
        /// Mã quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? DistrictCode { get; set; }

        /// <summary>
        /// Tên quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? DistrictName { get; set; }

        /// <summary>
        /// Mã xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? WardCode { get; set; }

        /// <summary>
        /// Tên xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? WardName { get; set; }


        // HỘ KHẨU THƯỜNG TRÚ
        /// <summary>
        /// Mã tỉnh/thành phố (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyPermanentAddressProvinceCode { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? FamilyPermanentAddressProvinceName { get; set; }

        /// <summary>
        /// Mã quận/huyện (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyPermanentAddressDistrictCode { get; set; }

        /// <summary>
        /// Tên quận/huyện (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? FamilyPermanentAddressDistrictName { get; set; }

        /// <summary>
        /// Mã xã/phường (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyPermanentAddressWardCode { get; set; }

        /// <summary>
        /// Tên xã/phường (theo hộ khẩu thường trú)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? FamilyPermanentAddressWardName { get; set; }

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
        /// Tên tỉnh/thành phố (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? FamilyCurrentProvinceName { get; set; }

        /// <summary>
        /// Mã quận/huyện (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyCurrentDistrictCode { get; set; }

        /// <summary>
        /// Tên quận/huyện (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? FamilyCurrentDistrictName { get; set; }

        /// <summary>
        /// Mã xã/phường (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? FamilyCurrentWardCode { get; set; }

        /// <summary>
        /// Tên xã/phường (theo chỗ ở hiện nay)
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? FamilyCurrentWardName { get; set; }

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
        public EditMode? EditMode { get; set; }
    }
}

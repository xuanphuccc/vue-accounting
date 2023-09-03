using MISA.AmisMintax.Domain;
using MISA.AmisMintax.Domain.Resources.InputValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class EmployeeUpdateDto
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã Loại đối tượng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public EmployeeType? EmployeeType { get; set; }

        /// <summary>
        /// Tên Loại đối tượng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? EmployeeTypeName { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        [RegularExpression(@"NV[0-9]{4,}", ErrorMessageResourceName = nameof(InputValidation.CodeFormat), ErrorMessageResourceType = typeof(InputValidation))]
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Ho tên
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        [StringLength(100, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Mã giới tính
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public Gender? Gender { get; set; }

        /// <summary>
        /// Tên giới tính
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? GenderName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(50, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? Mobile { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(100, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? Email { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(25, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? TaxCode { get; set; }

        /// <summary>
        /// Mã loại giấy tờ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public IdentifyType? IdentifyType { get; set; }

        /// <summary>
        /// Tên loại giấy tờ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? IdentifyTypeName { get; set; }

        /// <summary>
        /// Số chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(25, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? IdentifyNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? IdentifyDate { get; set; }

        /// <summary>
        /// Mã nơi cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? IdentifyIssuedPlaceCode { get; set; }

        /// <summary>
        /// Tên nơi cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? IdentifyIssuedPlaceName { get; set; }

        /// <summary>
        /// Mã quốc tịch
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NationalCode { get; set; }

        /// <summary>
        /// Tên quốc tịch
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? NationalName { get; set; }

        /// <summary>
        /// Loại hợp đồng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public ContractType? ContractMintaxType { get; set; }

        /// <summary>
        /// Tên loại hợp đồng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? ContractMintaxTypeName { get; set; }


        // HỘ KHẨU THƯỜNG TRÚ
        /// <summary>
        /// Mã quốc gia
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NativeCountryCode { get; set; }

        /// <summary>
        /// Tên quốc gia
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? NativeCountryName { get; set; }

        /// <summary>
        /// Mã tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NativeProvinceCode { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? NativeProvinceName { get; set; }

        /// <summary>
        /// Mã quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NativeDistrictCode { get; set; }

        /// <summary>
        /// Tên quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? NativeDistrictName { get; set; }

        /// <summary>
        /// Mã xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NativeWardCode { get; set; }

        /// <summary>
        /// Tên xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? NativeWardName { get; set; }

        /// <summary>
        /// Số nhà, đường/phố, thôn/xóm
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? NativeStreetHouseNumber { get; set; }


        // CHỖ Ở HIỆN NAY
        /// <summary>
        /// Giống hộ khẩu thường trú
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public bool? IsCopyAddress { get; set; }

        /// <summary>
        /// Mã quốc gia
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? CurrentCountryCode { get; set; }

        /// <summary>
        /// Tên quốc gia
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? CurrentCountryName { get; set; }

        /// <summary>
        /// Mã tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? CurrentProvinceCode { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? CurrentProvinceName { get; set; }

        /// <summary>
        /// Mã quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? CurrentDistrictCode { get; set; }

        /// <summary>
        /// Tên quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? CurrentDistrictName { get; set; }

        /// <summary>
        /// Mã xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? CurrentWardCode { get; set; }

        /// <summary>
        /// Tên xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? CurrentWardName { get; set; }

        /// <summary>
        /// Số nhà, đường/phố, thôn/xóm
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(255, ErrorMessageResourceName = nameof(InputValidation.MaxLength), ErrorMessageResourceType = typeof(InputValidation))]
        public string? CurrentStreetHouseNumber { get; set; }


        // THÔNG TIN CÔNG VIỆC
        /// <summary>
        /// Mã bộ phận/phòng ban
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? OrganizationUnitId { get; set; }

        /// <summary>
        /// Tên bộ phận/phòng ban
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? OrganizationUnitName { get; set; }

        /// <summary>
        /// Mã vị trí công việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? JobPositionId { get; set; }

        /// <summary>
        /// Tên vị trí công việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? JobPositionName { get; set; }

        /// <summary>
        /// Mã chức danh
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? JobTitleId { get; set; }

        /// <summary>
        /// Mã trạng thái làm việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public WorkStatus? EmployeeStatus { get; set; }

        /// <summary>
        /// Tên trạng thái làm việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public string? EmployeeStatusName { get; set; }

        /// <summary>
        /// Ngày học việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? ProbationDate { get; set; }

        /// <summary>
        /// Ngày thử việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? HireDate { get; set; }

        /// <summary>
        /// Ngày chính thức
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? ReceiveDate { get; set; }

        /// <summary>
        /// Ngày nghỉ việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public DateTime? TerminationDate { get; set; }

        /// <summary>
        /// Trạng thái sử dụng
        /// </summary>
        /// CreatedBy: txphuc (21/08/2023)
        public bool? UsageStatus { get; set; }

        /// <summary>
        /// Danh sách người thân của nhân viên
        /// </summary>
        /// CreatedBy: txphuc (21/08/2023)
        public List<EmployeeRelationshipUpdateDto> EmployeeRelationships { get; set; } = new();
    }
}

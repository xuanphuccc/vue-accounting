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
    public class EmployeeDto
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        public string EmployeeID { get; set; } = string.Empty;

        /// <summary>
        /// Mã Loại đối tượng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? EmployeeType { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        [StringLength(20)]
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Ho tên
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        [StringLength(100)]
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
        /// Số điện thoại
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(50)]
        public string? Mobile { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(25)]
        public string? TaxCode { get; set; }

        /// <summary>
        /// Mã loại giấy tờ
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? IdentifyType { get; set; }

        /// <summary>
        /// Số chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        [StringLength(25)]
        public string IdentifyNumber { get; set; } = string.Empty;

        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        public DateTime IdentifyDate { get; set; }

        /// <summary>
        /// Mã nơi cấp
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        [StringLength(20)]
        public string IdentifyIssuedPlaceCode { get; set; } = string.Empty;

        /// <summary>
        /// Mã quốc tịch
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? NationalCode { get; set; }

        /// <summary>
        /// Loại hợp đồng
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [Required]
        public int ContractMintaxType { get; set; }


        // HỘ KHẨU THƯỜNG TRÚ
        /// <summary>
        /// Mã quốc gia
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? NativeCountryCode { get; set; }

        /// <summary>
        /// Mã tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? NativeProvinceCode { get; set; }

        /// <summary>
        /// Mã quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? NativeDistrictCode { get; set; }

        /// <summary>
        /// Mã xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? NativeWardCode { get; set; }

        /// <summary>
        /// Số nhà, đường/phố, thôn/xóm
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(255)]
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
        [StringLength(20)]
        public string? CurrentCountryCode { get; set; }

        /// <summary>
        /// Mã tỉnh/thành phố
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? CurrentProvinceCode { get; set; }

        /// <summary>
        /// Mã quận/huyện
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? CurrentDistrictCode { get; set; }

        /// <summary>
        /// Mã xã/phường
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(20)]
        public string? CurrentWardCode { get; set; }

        /// <summary>
        /// Số nhà, đường/phố, thôn/xóm
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        [StringLength(255)]
        public string? CurrentStreetHouseNumber { get; set; }


        // THÔNG TIN CÔNG VIỆC
        /// <summary>
        /// Mã bộ phận/phòng ban
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? OrganizationUnitId { get; set; }

        /// <summary>
        /// Mã vị trí công việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? JobPositionId { get; set; }

        /// <summary>
        /// Mã chức danh
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? JobTitleId { get; set; }

        /// <summary>
        /// Mã trạng thái làm việc
        /// </summary>
        /// CreatedBy: txphuc (19/08/2023)
        public int? EmployeeStatus { get; set; }

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

        List<EmployeeRelationshipDto>? EmployeeRelationships { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public class EmployeeFilterModel
    {
        /// <summary>
        /// Trang hiện tại
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        [Required]
        public int Page { get; set; }

        /// <summary>
        /// Số phần tử trên trang
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        [Required]
        public int PageSize { get; set; }

        /// <summary>
        /// Search theo mã, tên và số điện thoại
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? Search { get; set; }

        /// <summary>
        /// Trạng thái sử dụng
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public bool? UsageStatus { get; set; }

        /// <summary>
        /// Sắp xếp theo cột
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? SortColumn { get; set; }

        /// <summary>
        /// Loại sắp xếp:
        /// asc - Sắp xếp tăng dần
        /// desc - Sắp xếp giảm dần
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? SortOrder { get; set; }

        /// <summary>
        /// Trạng thái làm việc
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Loại filter (equal, notequal, contain, notcontain,...)
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public string? WorkStatusFilterBy { get; set; }

        /// <summary>
        /// Loại đối tượng (nhân viên, vãng lai)
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public int? EmployeeType { get; set; }

        /// <summary>
        /// Loại filter (equal, notequal, contain, notcontain,...)
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public string? EmployeeTypeFilterBy { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public string? TaxCode { get; set; }

        /// <summary>
        /// Loại filter (equal, notequal, contain, notcontain,...)
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public string? TaxCodeFilterBy { get; set; }

        /// <summary>
        /// Cột cần filter theo ngày
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public string? DateColumn { get; set; }

        /// <summary>
        /// Loại filter (equal, notequal, contain, notcontain,...)
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public string? DateColumnFilterBy { get;set; }

        /// <summary>
        /// Filter ngày bắt đầu
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public DateTime? DateStart { get; set; }

        /// <summary>
        /// Filter ngày kết thúc
        /// </summary>
        /// CreatedBy: txphuc (22/08/2023)
        public DateTime? DateEnd { get; set; }
    }
}

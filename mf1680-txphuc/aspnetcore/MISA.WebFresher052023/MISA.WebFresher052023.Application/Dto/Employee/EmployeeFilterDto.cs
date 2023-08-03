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
    public class EmployeeFilterDto
    {
        /// <summary>
        /// Search theo mã, tên và số điện thoại
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? Search { get; set; }

        /// <summary>
        /// Sắp xếp theo cột
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? SortColumn { get; set; }

        /// <summary>
        /// Loại sắp xếp:
        /// ASC - Sắp xếp tăng dần
        /// DESC - Sắp xếp giảm dần
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? SortOrder { get; set; }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public int Page { get; set; }

        /// <summary>
        /// Số phần tử trên trang
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        [Required(ErrorMessageResourceName = nameof(InputValidation.IsRequired), ErrorMessageResourceType = typeof(InputValidation))]
        public int PageSize { get; set; }


        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? EmployeeCode { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? EmployeeCodeFilterBy { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? FullName { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? FullNameFilterBy { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public Gender? Gender { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? GenderFilterBy { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? DateOfBirthFilterBy { get; set; }

        /// <summary>
        /// Số chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? IdentityNumberFilterBy { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? PositionName { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? PositionNameFilterBy { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? DepartmentNameFilterBy { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? BankAccount { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? BankAccountFilterBy { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? BankName { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? BankNameFilterBy { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? BankBranch { get; set; }

        /// <summary>
        /// Lọc theo tiêu chí nào:
        /// EQUAL - Bằng
        /// NOTEQUAL - Khác
        /// CONTAIN - Chứa
        /// NOTCONTAIN - Không chứa
        /// </summary>
        /// CreatedBy: txphuc (03/08/2023)
        public string? BankBranchFilterBy { get; set; }
    }
}

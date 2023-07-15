using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class Pagination
    {
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        /// CreatedBy: txphuc (15/07/2023)
        public object? Data { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        /// CreatedBy: txphuc (15/07/2023)
        public int? TotalPages { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// CreatedBy: txphuc (15/07/2023)
        public int? TotalRecords { get; set; }
    }
}

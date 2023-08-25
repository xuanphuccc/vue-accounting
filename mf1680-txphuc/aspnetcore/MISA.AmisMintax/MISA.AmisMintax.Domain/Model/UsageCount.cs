using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public class UsageCount
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// CreatedBy: txphuc (25/08/2023)
        public int? TotalRecords { get; set; }

        /// <summary>
        /// Số bản ghi đang được sử dụng
        /// </summary>
        /// CreatedBy: txphuc (25/08/2023)
        public int? UsedRecords { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public interface IExcelService
    {
        /// <summary>
        /// Xử lý xuất file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (23/07/2023)
        Task<byte[]> ExportToExcelAsync();

        /// <summary>
        /// Xử lý nhập file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (23/07/2023)
        Task ImportExcelAsync();
    }
}

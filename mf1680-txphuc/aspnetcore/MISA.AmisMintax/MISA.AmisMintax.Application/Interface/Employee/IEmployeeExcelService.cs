using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public interface IEmployeeExcelService : IExcelCore
    {
        /// <summary>
        /// Xuất toàn bộ dữ liệu ra file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (28/08/2023)
        Task<byte[]> ExportAllToExcelAsync(List<ExcelExportSheetDto> exportSheetDtos);

        /// <summary>
        /// Xuất danh sách theo ID ra file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (28/08/2023)
        Task<byte[]> ExportListToExcelAsync(List<Guid> employeeIds,List<ExcelExportSheetDto> exportSheetDtos);
    }
}

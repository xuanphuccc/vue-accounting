using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public interface IExcelCore
    {
        /// <summary>
        /// Thêm một trang tính mới
        /// </summary>
        /// <param name="entityDtos">Dữ liệu ghi ra trang tính</param>
        /// <param name="exportSheetDto">Cấu hình trang tính</param>
        /// CreatedBy: txphuc (28/08/2023)
        void AddWorkSheet(IEnumerable<object> entityDtos, ExcelExportSheetDto exportSheetDto);

        /// <summary>
        /// Lấy mảng bytes của file Excel để download 
        /// (bao gồm tất cả trang tính đã thêm)
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (28/08/2023)
        byte[] GetExcelBytes();
    }
}

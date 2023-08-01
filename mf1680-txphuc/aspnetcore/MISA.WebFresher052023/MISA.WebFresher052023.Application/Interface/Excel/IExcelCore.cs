using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public interface IExcelCore<TEntityDto, TEntityExcelInsertDto>
    {
        /// <summary>
        /// Xử lý xuất file Excel
        /// </summary>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (23/07/2023)
        byte[] ExportToExcel(IEnumerable<TEntityDto> entityDtos, IEnumerable<ExcelColumnDto> columns);

        /// <summary>
        /// Lấy dữ liệu về tên các cột trong file Excel
        /// và tên các thuộc tính của đối tượng cần map từ các cột đó
        /// </summary>
        /// <param name="excelGetMapDto">Thông tin của file Excel</param>
        /// <returns>
        /// Gồm hai danh sách:
        /// - Danh sách tên các cột trong file Excel và vị trí cột
        /// - Danh sách tên các thuộc tính của đối tượng
        /// </returns>
        /// CreatedBy: txphuc (29/07/2023)
        ExcelMapResponseDto GetMapExcel(ExcelGetMapDto excelGetMapDto);

        /// <summary>
        /// Đọc data từ file Excel và map sang đối tượng
        /// </summary>
        /// <param name="excelMapRequestDto">
        /// Chứa thông tin về file Excel và danh sách hướng dẫn map
        /// </param>
        /// <returns>Danh sách các đối tượng đã đọc từ file Excel</returns>
        IEnumerable<TEntityExcelInsertDto> ReadExcelData(ExcelMapRequestDto excelMapRequestDto);
    }
}

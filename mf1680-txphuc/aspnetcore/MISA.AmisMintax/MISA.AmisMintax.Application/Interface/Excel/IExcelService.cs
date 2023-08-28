﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application.Interface
{
    public interface IExcelService : IExcelCore
    {
        /// <summary>
        /// Xuất toàn bộ danh sách theo các cột được chỉ định
        /// </summary>
        /// <param name="columns">Danh sách các cột muốn hiển thị</param>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (26/07/2023)
        Task<byte[]> ExportAll(IEnumerable<ExcelExportColumnDto> columns);

        /// <summary>
        /// Xuất danh sách các bản ghi, và theo cột được chỉ định
        /// </summary>
        /// <param name="entityIds">Danh sách Id của các bản ghi muốn xuất</param>
        /// <param name="columns">Danh sách các cột muốn hiển thị</param>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (26/07/2023)
        Task<byte[]> ExportList(IEnumerable<Guid> entityIds, IEnumerable<ExcelExportColumnDto> columns);
    }
}

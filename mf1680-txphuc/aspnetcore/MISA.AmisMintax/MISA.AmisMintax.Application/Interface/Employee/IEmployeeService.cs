using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public interface IEmployeeService : IBaseCodeService<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        /// <summary>
        /// Tìm kiếm, filter và phân trang
        /// </summary>
        /// <param name="employeeFilterDto"></param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (21/08/2023)
        Task<Pagination> FilterAsync(EmployeeFilterDto employeeFilterDto);

        /// <summary>
        /// Đếm số bản ghi đang được sử dụng
        /// </summary>
        /// <returns>Số bản ghi đang được sử dụng và tổng số bản ghi</returns>
        /// CreatedBy: txphuc (25/08/2023)
        Task<UsageCount> GetUsageCountAsync();
    }
}

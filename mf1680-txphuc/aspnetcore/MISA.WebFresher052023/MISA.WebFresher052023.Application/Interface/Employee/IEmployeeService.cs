using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public interface IEmployeeService : IBaseCodeService<EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>
    {
        /// <summary>
        /// Tìm kiếm, filter và phân trang
        /// </summary>
        /// <param name="employeeFilterDto">Các param cho filter và phân trang</param>
        /// <returns>Danh sách nhân viên đã được filter và phân trang</returns>
        /// CreatedBy: txphuc (15/07/2023)
        Task<Pagination> FilterAsync(EmployeeFilterDto employeeFilterDto);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public interface IEmployeeRepository : IBaseCodeRepository<Employee>
    {
        /// <summary>
        /// Tìm kiếm, filter, sắp xếp, phân trang
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <returns>Thông tin phân trang</returns>
        Task<Pagination> FilterAsync(EmployeeFilterModel employeeFilter);
    } 
}

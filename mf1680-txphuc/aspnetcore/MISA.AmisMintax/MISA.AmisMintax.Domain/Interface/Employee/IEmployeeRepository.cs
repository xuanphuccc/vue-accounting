using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public interface IEmployeeRepository : IBaseCodeRepository<Employee, Employee>
    {
        /// <summary>
        /// Tìm kiếm, filter, sắp xếp, phân trang
        /// </summary>
        /// <param name="employeeFilter"></param>
        /// <returns>Thông tin phân trang</returns>
        /// CreatedBy: txphuc (20/08/2023)
        Task<Pagination> FilterAsync(EmployeeFilterModel employeeFilter);

        /// <summary>
        /// Đếm số bản ghi đang được sử dụng
        /// </summary>
        /// <returns>Số bản ghi đang được sử dụng và tổng số bản ghi</returns>
        /// CreatedBy: txphuc (25/08/2023)
        Task<UsageCount> GetUsageCountAsync();

        /// <summary>
        /// Tìm thông tin nhân viên theo mã số thuế
        /// </summary>
        /// <param name="taxCode">Mã số thuế</param>
        /// <returns>Bản ghi thoả mãn</returns>
        /// CreatedBy: txphuc (02/09/2023)
        Task<Employee> FindByTaxCodeAsync(string taxCode);

        /// <summary>
        /// Tìm thông tin nhân viên theo số CMND/CCCD/Hộ chiếu
        /// </summary>
        /// <param name="identifyNumber">Số CMND/CCCD/Hộ chiếu</param>
        /// <returns>Bản ghi thoả mãn</returns>
        /// CreatedBy: txphuc (02/09/2023)
        Task<Employee> FindByIdentifyNumberAsync(string identifyNumber);
    } 
}

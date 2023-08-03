using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IDepartmentRepository : IBaseCodeRepository<Department, Department>
    {
        /// <summary>
        /// Lấy số bản ghi phụ thuộc vào bản ghi hiện tại
        /// </summary>
        /// <param name="departmentId">đơn vị</param>
        /// <returns>Số bản ghi phụ thuộc</returns>
        Task<int> CheckConstraintByIdAsync(Guid departmentId);

        /// <summary>
        /// Lấy các bản ghi có phụ thuộc
        /// </summary>
        /// <param name="departmentIds">Danh sách Id của đơn vị</param>
        /// <returns>Mã của các đơn vị có phụ thuộc</returns>
        Task<IEnumerable<string>> CheckListConstraintAsync(IEnumerable<Guid> departmentIds);
    }
}

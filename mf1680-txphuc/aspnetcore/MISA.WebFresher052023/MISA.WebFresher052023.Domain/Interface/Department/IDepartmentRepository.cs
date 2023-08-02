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
        /// <param name="department">đơn vị</param>
        /// <returns>Số bản ghi phụ thuộc</returns>
        Task<int> CheckConstraintByIdAsync(Department department);

        /// <summary>
        /// Lấy các bản ghi có phụ thuộc
        /// </summary>
        /// <param name="departments">Danh sách đơn vị</param>
        /// <returns>Mã của các đơn vị có phụ thuộc</returns>
        Task<IEnumerable<string>> CheckListConstraintAsync(IEnumerable<Department> departments);
    }
}

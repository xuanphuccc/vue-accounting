using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain.Interface
{
    public interface IEmployeeRelationshipRepository : IBaseRepository<EmployeeRelationship, EmployeeRelationshipModel>
    {
        /// <summary>
        /// Lấy danh sách người thân theo Id nhân viên
        /// </summary>
        /// <param name="employeeIds">Danh sách Id của nhân viên muốn lấy danh sách người thân</param>
        /// <returns>Danh sách người thân của nhân viên</returns>
        /// CreatedBy: txphuc (22/08/2023)
        Task<IEnumerable<EmployeeRelationshipModel>> GetListByEmployeeIdAsync(IEnumerable<Guid> employeeIds);
    }
}

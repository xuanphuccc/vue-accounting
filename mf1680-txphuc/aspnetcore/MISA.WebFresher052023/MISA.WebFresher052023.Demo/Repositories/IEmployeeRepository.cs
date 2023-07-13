using MISA.WebFresher052023.Demo.Dtos;
using MISA.WebFresher052023.Demo.Entities;

namespace MISA.WebFresher052023.Demo.Repositories
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get toàn bộ nhân viên
        /// </summary>
        /// <returns>Trả về danh sách nhân viên</returns>
        /// CreatedBy: txphuc (12/07/2023)
        Task<IEnumerable<Employee>> GetAll();

        /// <summary>
        /// Get một nhân viên thông qua Id
        /// </summary>
        /// <param name="employeeId">Mã nhân viên</param>
        /// <returns>Trả về một nhân viên thoả mãn</returns>
        /// CreatedBy: txphuc (12/07/2023)
        Task<Employee> GetById(Guid employeeId);

        /// <summary>
        /// Tạo nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Trả về nhân viên được tạo thành công</returns>
        /// CreatedBy: txphuc (12/07/2023)
        Task<int> Create(Employee employee);

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (12/07/2023)
        Task<int> Update(Guid employeeId, Employee employee);

        /// <summary>
        /// Xoá một nhân viên thông qua Id
        /// </summary>
        /// <param name="employeeId">Mã nhân viên</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (13/07/2023)
        Task<int> DeleteById(Guid employeeId);

        /// <summary>
        /// Xoá nhiều nhân viên nhân viên thông qua mảng các Id
        /// </summary>
        /// <param name="employeeIds">Mảng mã nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (13/07/2023)
        Task<int> Delete(Guid[] employeeIds);
    }
}

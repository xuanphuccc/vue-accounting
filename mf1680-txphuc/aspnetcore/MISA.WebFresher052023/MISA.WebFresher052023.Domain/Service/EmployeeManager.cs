using MISA.WebFresher052023.Domain.Resources.Common;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPositionRepository _positionRepository;
        #endregion

        #region Constructors
        public EmployeeManager(
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Check trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần check</param>
        /// <param name="oldEmployeeCode">Mã nhân viên cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (14/07/2023)
        public async Task CheckExistEmployeeCode(string employeeCode, string? oldEmployeeCode = null)
        {
            var existEmployee = await _employeeRepository.FindByCodeAsync(employeeCode);

            if (existEmployee != null && existEmployee.EmployeeCode != oldEmployeeCode)
            {
                var errorMessage = String.Format(ErrorMessage.ConflictCode, CommonResource.Employee, employeeCode);
                throw new ConflictException(errorMessage, ErrorCode.ConflictCode);
            }
        }

        /// <summary>
        /// Check các khoá ngoại có tồn tại hay không
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <param name="positionId">Id của vị trí</param>
        /// CreatedBy: txphuc (17/07/2023)
        public async Task CheckValidConstraint(Guid departmentId, Guid? positionId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            if (positionId != null)
            {
                var position = await _positionRepository.GetByIdAsync(positionId.Value);
            }
        }
        #endregion
    }
}

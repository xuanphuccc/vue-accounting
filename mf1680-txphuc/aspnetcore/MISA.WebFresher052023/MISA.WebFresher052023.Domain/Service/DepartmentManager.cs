using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class DepartmentManager : IDepartmentManager
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructors
        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Check trùng mã đơn vị
        /// </summary>
        /// <param name="departmentCode">Mã đơn vị</param>
        /// <param name="oldDepartmentCode">Mã đơn vị cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task CheckExistDepartmentCode(string departmentCode, string? oldDepartmentCode = null)
        {
            var existDeparment = await _departmentRepository.FindByCodeAsync(departmentCode);

            if (existDeparment != null && existDeparment.DepartmentCode != oldDepartmentCode)
            {
                throw new ConflictException($"{ErrorMessage.ConflictCode}: '{departmentCode}'", ErrorCode.ConflictCode);
            }
        }
        #endregion
    }
}

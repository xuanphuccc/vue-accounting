using MISA.WebFresher052023.Domain.Resources.Common;
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
                var errorMessage = String.Format(ErrorMessage.ConflictCode, CommonResource.Department, departmentCode);
                throw new ConflictException(errorMessage, ErrorCode.ConflictCode);
            }
        }

        /// <summary>
        /// Check mã đơn vị tối đa có thể nhập
        /// </summary>
        /// <param name="departmentCode">Mã đơn vị cần check</param>
        /// CreatedBy: txphuc (08/08/2023)
        public async Task CheckMaxDepartmentCode(string departmentCode)
        {
            // Lấy mã mới trong hệ thống
            var newDepartmentCode = await _departmentRepository.FindNewCodeAsync();

            if (newDepartmentCode != null)
            {
                // Chuyển mã được cấp sang số nguyên
                var newCodeNumber = Convert.ToInt32(newDepartmentCode.Substring(newDepartmentCode.IndexOf("-") + 1));

                // Mã tối đa cho phép nhập
                var maxCodeNumber = newCodeNumber + 10;

                // Chuyển mã đã nhập sang số nguyên
                var inputCodeNumber = Convert.ToInt32(departmentCode.Substring(departmentCode.IndexOf("-") + 1));

                if (inputCodeNumber > maxCodeNumber)
                {
                    var errorMessage = string.Format(ErrorMessage.MaxCodeError, newDepartmentCode);

                    throw new MaxCodeException(errorMessage, ErrorCode.MaxCodeError);
                }
            }
        }
        #endregion
    }
}

using MISA.WebFresher052023.Domain.Resources.Common;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class PositionManager : IPositionManager
    {
        #region Fields
        private readonly IPositionRepository _positionRepository;
        #endregion

        #region Constructors
        public PositionManager(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }
        #endregion



        #region Methods
        /// <summary>
        /// Check trùng mã vị trí
        /// </summary>
        /// <param name="positionCode">Mã vị trí</param>
        /// <param name="oldPositionCode">Mã vị trí cũ (trong trường hợp cập nhật mã)</param>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task CheckExistPositionCode(string positionCode, string? oldPositionCode = null)
        {
            var existPosition = await _positionRepository.FindByCodeAsync(positionCode);

            if (existPosition != null && existPosition.PositionCode != oldPositionCode)
            {
                var errorMessage = String.Format(ErrorMessage.ConflictCode, CommonResource.Position, positionCode);
                throw new ConflictException(errorMessage, ErrorCode.ConflictCode);
            }
        }

        /// <summary>
        /// Check mã vị trí tối đa có thể nhập
        /// </summary>
        /// <param name="positionCode">Mã vị trí cần check</param>
        /// CreatedBy: txphuc (08/08/2023)
        public async Task CheckMaxPositionCode(string positionCode)
        {
            // Lấy mã mới trong hệ thống
            var newPositionCode = await _positionRepository.FindNewCodeAsync();

            if (newPositionCode != null)
            {
                // Chuyển mã được cấp sang số nguyên
                var newCodeNumber = Convert.ToInt32(newPositionCode.Substring(newPositionCode.IndexOf("-") + 1));

                // Mã tối đa cho phép nhập
                var maxCodeNumber = newCodeNumber + 10;

                // Chuyển mã đã nhập sang số nguyên
                var inputCodeNumber = Convert.ToInt32(positionCode.Substring(positionCode.IndexOf("-") + 1));

                if (inputCodeNumber > maxCodeNumber)
                {
                    var errorMessage = string.Format(ErrorMessage.MaxCodeError, newPositionCode);

                    throw new MaxCodeException(errorMessage, ErrorCode.MaxCodeError);
                }
            }
        }
        #endregion
    }
}

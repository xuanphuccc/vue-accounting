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
                throw new ConflictException($"{ErrorMessage.ConflictCode}: '{positionCode}'", ErrorCode.ConflictCode);
            }
        }
        #endregion
    }
}

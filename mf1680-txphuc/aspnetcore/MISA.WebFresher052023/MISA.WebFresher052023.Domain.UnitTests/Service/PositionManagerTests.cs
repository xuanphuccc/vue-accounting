using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain.UnitTests
{
    [TestFixture]
    public class PositionManagerTests
    {
        #region Fields
        private IPositionRepository _positionRepository;
        private PositionManager _positionManager;
        #endregion

        #region Methods
        [SetUp]
        public void Setup()
        {
            _positionRepository = Substitute.For<IPositionRepository>();
            _positionManager = new PositionManager(_positionRepository);
        }

        /// <summary>
        /// Trường hợp mã vị trí đã tồn tại và khác với mã cũ của nó
        /// </summary>
        /// <returns>Trả về ConflictException</returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task CheckExistPositionCode_ExistPosition_ConflictException()
        {
            // Arrange
            var code = "txphuc";
            var oldCode = "unittest"; // Mã cũ (trong trường hợp cập nhật mã)

            _positionRepository.FindByCodeAsync(code).Returns(new Position() { PositionCode = code });

            // Act & Assert
            Assert.ThrowsAsync<ConflictException>(async () =>
            await _positionManager.CheckExistPositionCode(code, oldCode));

            // Đảm bảo FindByCodeAsync chỉ được gọi 1 lần
            await _positionRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Trường hợp mã vị trí chưa tồn tại
        /// </summary>
        /// <returns>Validate thành công</returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task CheckExistPositionCode_NotExistPosition_Success()
        {
            // Arrange
            var code = "txphuc";

            _positionRepository.FindByCodeAsync(code).Returns(Task.FromResult<Position?>(null));

            // Act
            await _positionManager.CheckExistPositionCode(code);

            // Assert
            await _positionRepository.Received(1).FindByCodeAsync(code);
        } 
        #endregion
    }
}

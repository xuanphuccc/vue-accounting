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
    public class DepartmentManagerTests
    {
        #region Fields
        private IDepartmentRepository _departmentRepository;
        private DepartmentManager _departmentManager;
        #endregion

        #region Methods
        [SetUp]
        public void Setup()
        {
            _departmentRepository = Substitute.For<IDepartmentRepository>();
            _departmentManager = new DepartmentManager(_departmentRepository);
        }

        /// <summary>
        /// Trường hợp mã đơn vị đã tồn tại và khác với mã cũ của nó
        /// </summary>
        /// <returns>Trả về ConflictException</returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task CheckExistDepartmentCode_ExistDepartment_ConflictException()
        {
            // Arrange
            var code = "txphuc";
            var oldCode = "unittest"; // Mã cũ (trong trường hợp cập nhật mã)

            _departmentRepository.FindByCodeAsync(code).Returns(new Department() { DepartmentCode = code });

            // Act & Assert
            Assert.ThrowsAsync<ConflictException>(async () =>
            await _departmentManager.CheckExistDepartmentCode(code, oldCode));

            // Đảm bảo FindByCodeAsync chỉ được gọi 1 lần
            await _departmentRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Trường hợp mã đơn vị chưa tồn tại
        /// </summary>
        /// <returns>Validate thành công</returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task CheckExistDepartmentCode_NotExistDepartment_Success()
        {
            // Arrange
            var code = "txphuc";

            _departmentRepository.FindByCodeAsync(code).Returns(Task.FromResult<Department?>(null));

            // Act
            await _departmentManager.CheckExistDepartmentCode(code);

            // Assert
            await _departmentRepository.Received(1).FindByCodeAsync(code);
        } 
        #endregion
    }
}

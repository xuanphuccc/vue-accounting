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
        public IDepartmentRepository departmentRepository { get; set; }
        public DepartmentManager departmentManager { get; set; }
        #endregion

        #region Methods
        [SetUp]
        public void Setup()
        {
            departmentRepository = Substitute.For<IDepartmentRepository>();
            departmentManager = new DepartmentManager(departmentRepository);
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

            departmentRepository.FindByCodeAsync(code).Returns(new Department() { DepartmentCode = code });

            // Act & Assert
            Assert.ThrowsAsync<ConflictException>(async () =>
            await departmentManager.CheckExistDepartmentCode(code, oldCode));

            // Đảm bảo FindByCodeAsync chỉ được gọi 1 lần
            await departmentRepository.Received(1).FindByCodeAsync(code);
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

            departmentRepository.FindByCodeAsync(code).Returns(Task.FromResult<Department?>(null));

            // Act
            await departmentManager.CheckExistDepartmentCode(code);

            // Assert
            await departmentRepository.Received(1).FindByCodeAsync(code);
        } 
        #endregion
    }
}

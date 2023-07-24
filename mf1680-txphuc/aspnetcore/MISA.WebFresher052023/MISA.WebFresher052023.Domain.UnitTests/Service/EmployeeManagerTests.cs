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
    public class EmployeeManagerTests
    {
        /// <summary>
        /// Trường hợp mã nhân viên đã tồn tại và khác với mã cũ của nó
        /// </summary>
        /// <returns>Trả về ConflictException</returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task CheckExistEmployeeCode_ExistEmployee_ConflictException()
        {
            // Arrange
            var code = "txphuc";
            var oldCode = "unittest"; // Mã cũ (trong trường hợp cập nhật mã)

            var departmentRepository = Substitute.For<IDepartmentRepository>();
            var positionRepository = Substitute.For<IPositionRepository>();
            var employeeRepository = Substitute.For<IEmployeeRepository>();

            // Giá trị trả về khi gọi FindByCodeAsync
            employeeRepository.FindByCodeAsync(code).Returns(new Employee() { EmployeeCode = code });

            var employeeManager = new EmployeeManager(employeeRepository, departmentRepository, positionRepository);

            // Act & Assert
            Assert.ThrowsAsync<ConflictException>(async () =>
            await employeeManager.CheckExistEmployeeCode(code, oldCode));

            // Đảm bảo FindByCodeAsync chỉ được gọi 1 lần
            await employeeRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Trường hợp mã nhân viên chưa tồn tại
        /// </summary>
        /// <returns>Validate thành công</returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task CheckExistEmployeeCode_NotExistEmployee_Success()
        {
            // Arrange
            var code = "txphuc";

            var departmentRepository = Substitute.For<IDepartmentRepository>();
            var positionRepository = Substitute.For<IPositionRepository>();
            var employeeRepository = Substitute.For<IEmployeeRepository>();

            employeeRepository.FindByCodeAsync(code).Returns(Task.FromResult<Employee?>(null));

            var employeeManager = new EmployeeManager(employeeRepository, departmentRepository, positionRepository);

            // Act
            await employeeManager.CheckExistEmployeeCode(code);

            // Assert
            await employeeRepository.Received(1).FindByCodeAsync(code);
        }
    }
}

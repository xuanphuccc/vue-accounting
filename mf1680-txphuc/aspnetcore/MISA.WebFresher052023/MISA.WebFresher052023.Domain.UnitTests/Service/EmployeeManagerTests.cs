using NSubstitute;
using NSubstitute.ExceptionExtensions;
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
        #region Fields
        public IDepartmentRepository departmentRepository { get; set; }
        public IPositionRepository positionRepository { get; set; }
        public IEmployeeRepository employeeRepository { get; set; }
        public EmployeeManager employeeManager { get; set; }
        #endregion

        #region Methods
        [SetUp]
        public void Setup()
        {
            departmentRepository = Substitute.For<IDepartmentRepository>();
            positionRepository = Substitute.For<IPositionRepository>();
            employeeRepository = Substitute.For<IEmployeeRepository>();
            employeeManager = new EmployeeManager(employeeRepository, departmentRepository, positionRepository);
        }

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

            // Giá trị trả về khi gọi FindByCodeAsync
            employeeRepository.FindByCodeAsync(code).Returns(new Employee() { EmployeeCode = code });

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

            employeeRepository.FindByCodeAsync(code).Returns(Task.FromResult<Employee?>(null));

            // Act
            await employeeManager.CheckExistEmployeeCode(code);

            // Assert
            await employeeRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Trường hợp đầu vào hợp lệ
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task CheckValidConstraint_ValidInput_Success()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            var positionId = Guid.NewGuid();

            departmentRepository.GetByIdAsync(departmentId).Returns(new Department());
            positionRepository.GetByIdAsync(positionId).Returns(new Position());

            // Act
            await employeeManager.CheckValidConstraint(departmentId, positionId);

            // Assert
            await departmentRepository.Received(1).GetByIdAsync(departmentId);
            await positionRepository.Received(1).GetByIdAsync(positionId);
        }

        /// <summary>
        /// Trường hợp đầu vào không tồn tại
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public void CheckValidConstraint_InValidInput_ThrowException()
        {
            // Arrange
            var departmentId = Guid.NewGuid();
            var positionId = Guid.NewGuid();

            departmentRepository.GetByIdAsync(departmentId).ThrowsAsync(new NotFoundException());
            positionRepository.GetByIdAsync(positionId).ThrowsAsync(new NotFoundException());

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await employeeManager.CheckValidConstraint(departmentId, positionId));
        } 
        #endregion
    }
}

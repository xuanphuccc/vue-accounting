using AutoMapper;
using MISA.WebFresher052023.Domain;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        #region Fields
        public IEmployeeRepository employeeRepository { get; set; }
        public IEmployeeManager employeeManager { get; set; }
        public IMapper mapper { get; set; }
        public IUnitOfWork unitOfWork { get; set; }
        public EmployeeService employeeService { get; set; }
        #endregion

        /// <summary>
        /// Khởi tạo các phụ thuộc
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [SetUp]
        public void Setup()
        {
            employeeRepository = Substitute.For<IEmployeeRepository>();
            employeeManager = Substitute.For<IEmployeeManager>();
            unitOfWork = Substitute.For<IUnitOfWork>();
            employeeService = new EmployeeService(employeeRepository, employeeManager, unitOfWork, mapper);
            mapper = Substitute.For<IMapper>();
        }

        /// <summary>
        /// Test trường hợp truyền vào danh sách id rỗng
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public void DeleteAsync_EmptyList_ThrowException()
        {
            // Arrange
            List<Guid> ids = new();
            var expectedMessage = "Không thể xoá danh sách rỗng";

            // Act
            var exception = Assert.ThrowsAsync<Exception>(async () => await employeeService.DeleteAsync(ids));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Test trường hợp có đối tượng không tồn tại
        /// (ids.Count < employees.Count)
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public void DeleteAsync_ListItems_ThrowException()
        {
            // Arrange
            var expectedMessage = "Không thể xoá do có đối tượng không tồn tại";

            List<Guid> ids = new();

            for (int i = 0; i < 10; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            List<Employee> employees = new();

            for (int i = 0; i < 9; i++)
            {
                employees.Add(new Employee());
            }

            employeeRepository.GetListByIdsAsync(ids).Returns(employees);

            // Act
            var exception = Assert.ThrowsAsync<Exception>(async () => await employeeService.DeleteAsync(ids));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Test trường hợp danh sách Id tất cả đều hợp lệ
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task DeleteAsync_ListItems_Success()
        {
            // Arrange
            List<Guid> ids = new();

            for (int i = 0; i < 10; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            List<Employee> employees = new();

            for (int i = 0; i < 10; i++)
            {
                employees.Add(new Employee());
            }

            employeeRepository.GetListByIdsAsync(ids).Returns(employees);

            // Act
            await employeeService.DeleteAsync(ids);

            // Assert
            await employeeRepository.Received(1).GetListByIdsAsync(ids);

            await employeeRepository.Received(1).DeleteAsync(employees);
        }
    }
}

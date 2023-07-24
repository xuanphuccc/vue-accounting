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
        public IEmployeeRepository employeeRepository { get; set; }
        public IEmployeeManager employeeManager { get; set; }
        public IMapper mapper { get; set; }

        [SetUp]
        public void Setup()
        {
            employeeRepository = Substitute.For<IEmployeeRepository>();
            employeeManager = Substitute.For<IEmployeeManager>();
            mapper = Substitute.For<IMapper>();
        }

        [Test]
        public void DeleteAsync_EmptyList_ThrowException()
        {
            // Arrange
            List<Guid> ids = new();
            var expectedMessage = "Không thể xoá danh sách rỗng";

            var employeeService = new EmployeeService(employeeRepository, employeeManager, mapper);

            // Act
            var exception = Assert.ThrowsAsync<Exception>(async () => await employeeService.DeleteAsync(ids));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

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

            var employeeService = new EmployeeService(employeeRepository, employeeManager, mapper);

            // Act
            var exception = Assert.ThrowsAsync<Exception>(async () => await employeeService.DeleteAsync(ids));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }

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

            var employeeService = new EmployeeService(employeeRepository, employeeManager, mapper);

            // Act
            await employeeService.DeleteAsync(ids);

            // Assert
            await employeeRepository.Received(1).GetListByIdsAsync(ids);

            //await employeeRepository.Received(1).DeleteAsync(employees);
        }
    }
}

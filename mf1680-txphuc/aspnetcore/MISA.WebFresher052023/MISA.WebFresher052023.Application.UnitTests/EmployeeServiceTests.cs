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
        private IEmployeeRepository _employeeRepository;
        private IEmployeeManager _employeeManager;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private EmployeeService _employeeService;
        #endregion

        /// <summary>
        /// Khởi tạo các phụ thuộc
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [SetUp]
        public void Setup()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _employeeManager = Substitute.For<IEmployeeManager>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _employeeService = new EmployeeService(_employeeRepository, _employeeManager, _unitOfWork, _mapper);
            _mapper = Substitute.For<IMapper>();
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

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await _employeeService.DeleteAsync(ids));
        }

        /// <summary>
        /// Test trường hợp có đối tượng không tồn tại
        /// (ids.Count < employees.Count)
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task DeleteAsync_ListItems_ThrowException()
        {
            // Arrange
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

            _employeeRepository.GetListByIdsAsync(ids).Returns(employees);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await _employeeService.DeleteAsync(ids));

            await _employeeRepository.Received(1).GetListByIdsAsync(ids);
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

            _employeeRepository.GetListByIdsAsync(ids).Returns(employees);

            // Act
            await _employeeService.DeleteAsync(ids);

            // Assert
            await _employeeRepository.Received(1).GetListByIdsAsync(ids);

            await _employeeRepository.Received(1).DeleteAsync(employees);
        }
    }
}

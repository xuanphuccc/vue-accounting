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
    public class DepartmentServiceTests
    {
        #region Fields
        private IDepartmentRepository _departmentRepository;
        private IDepartmentManager _departmentManager;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private DepartmentService _departmentService;
        #endregion

        /// <summary>
        /// Khởi tạo các phụ thuộc
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [SetUp]
        public void Setup()
        {
            _departmentRepository = Substitute.For<IDepartmentRepository>();
            _departmentManager = Substitute.For<IDepartmentManager>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _departmentService = new DepartmentService(_departmentRepository, _departmentManager, _unitOfWork, _mapper);
            _mapper = Substitute.For<IMapper>();
        }

        /// <summary>
        /// Test trường hợp tất cả id đều hợp lệ (không có phụ thuộc)
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public async Task DeleteAsync_AllIdsValid_Success()
        {
            // Arrange
            var expectedResult = 10;
            List<Guid> ids = new();

            for (int i = 0; i < 10; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            _departmentRepository.CheckListConstraintAsync(ids).Returns(new List<Department>());
            _departmentRepository.DeleteAsync(ids).Returns(ids.Count);

            // Act
            var actualResult = await _departmentService.DeleteAsync(ids);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            await _departmentRepository.Received(1).DeleteAsync(ids);
        }

        /// <summary>
        /// Test trường hợp tất cả id đều không hợp lệ
        /// </summary>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public void DeleteAsync_AllIdsInvalid_ThrowException()
        {
            // Arrange
            List<Guid> ids = new();

            for (int i = 0; i < 10; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            List<Department> invalidDepartments = new();

            foreach (var id in ids)
            {
                // Chuyển tất cả Id thành Đối tượng không hợp lệ
                var department = new Department() { DepartmentId = id };
                invalidDepartments.Add(department);
            }

            _departmentRepository.CheckListConstraintAsync(ids).Returns(invalidDepartments);

            // Act & Assert
            Assert.ThrowsAsync<ConstraintException>(async () => await _departmentService.DeleteAsync(ids));
        }

        /// <summary>
        /// Test trường hợp danh sách Id tất cả đều hợp lệ
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: txphuc (24/07/2023)
        [Test]
        public void DeleteAsync_BothValidIdsAndInvalidIds_DeleteValidIdsAndThrowException()
        {
            // Arrange
            List<Guid> ids = new();

            for (int i = 0; i < 10; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            List<Department> invalidDepartments = new();

            for (int i = 0; i < 5; i++)
            {
                // Chuyển một nửa Id sang đối tượng không hợp lệ
                var department = new Department() { DepartmentId = ids[i] };
                invalidDepartments.Add(department);
            }

            _departmentRepository.CheckListConstraintAsync(ids).Returns(invalidDepartments);

            // Act & Assert
            Assert.ThrowsAsync<ConstraintException>(async () => await _departmentService.DeleteAsync(ids));
        }
    }
}

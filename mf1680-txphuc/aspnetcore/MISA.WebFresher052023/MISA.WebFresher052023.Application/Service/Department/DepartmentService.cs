using AutoMapper;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.Common;
using MISA.WebFresher052023.Domain.Resources.ErrorMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class DepartmentService :
        BaseCodeService<Department, Department, DepartmentDto, DepartmentCreateDto, DepartmentUpdateDto>,
        IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentManager _departmentManager;
        #endregion

        #region Constructors
        public DepartmentService(
            IDepartmentRepository departmentRepository,
            IDepartmentManager departmentManager,
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) : base(departmentRepository, unitOfWork, mapper)
        {
            _departmentRepository = departmentRepository;
            _departmentManager = departmentManager;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate nghiệp vụ cho Insert
        /// </summary>
        /// <param name="departmentCreateDto">CreateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override async Task<Department> MapCreateDtoToEntityAsync(DepartmentCreateDto departmentCreateDto)
        {
            // Check trùng mã đơn vị
            await _departmentManager.CheckExistDepartmentCode(departmentCreateDto.DepartmentCode);

            var department = _mapper.Map<Department>(departmentCreateDto);

            // Set Id cho bản ghi
            department.DepartmentId = Guid.NewGuid();

            return department;
        }

        /// <summary>
        /// Validate nghiệp vụ cho Update
        /// </summary>
        /// <param name="departmentId">Id của bản ghi</param>
        /// <param name="departmentUpdateDto">UpdateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override async Task<Department> MapUpdateDtoToEntityAsync(Guid departmentId, DepartmentUpdateDto departmentUpdateDto)
        {
            // Check đơn vị có tồn tại hay không
            var oldDepartment = await _departmentRepository.GetByIdAsync(departmentId);

            // Check trùng mã đơn vị
            await _departmentManager.CheckExistDepartmentCode(departmentUpdateDto.DepartmentCode, oldDepartment.DepartmentCode);

            var newDepartment = _mapper.Map(departmentUpdateDto, oldDepartment);

            return newDepartment;
        }

        /// <summary>
        /// Kiểm tra có bản ghi phụ thuộc hay không (cho trường hợp xoá một bản ghi)
        /// </summary>
        /// <param name="departmentId">Id của bản ghi</param>
        /// <returns></returns>
        protected override async Task CheckConstraintForDeleteAsync(Guid departmentId)
        {
            // Check bản ghi có phụ thuộc hay không
            var department = await _departmentRepository.CheckConstraintByIdAsync(departmentId);
            if (department != null)
            {
                var errorMessage = String.Format(ErrorMessage.ConstraintError, CommonResource.Department, department.DepartmentCode);
                throw new ConstraintException(errorMessage, ErrorCode.ConstraintError);
            }
        }

        /// <summary>
        /// Kiểm tra có bản ghi phụ thuộc hay không (cho trường hợp xoá nhiều)
        /// </summary>
        /// <param name="departmentIds">Danh sách Id của bản ghi</param>
        /// <returns></returns>
        protected override async Task CheckConstraintForDeleteManyAsync(List<Guid> departmentIds)
        {
            var departmentHaveConstraints = await _departmentRepository.CheckListConstraintAsync(departmentIds);

            // Trường hợp có bản ghi có phụ thuộc
            if (departmentHaveConstraints.ToList().Count > 0)
            {
                var errorDepartmentCodes = String.Join(", ", departmentHaveConstraints.ToList());
                var errorMessage = String.Format(ErrorMessage.ConstraintError, CommonResource.Department, errorDepartmentCodes);
                throw new ConstraintException(errorMessage, ErrorCode.ConstraintError);
            }
        }
        #endregion
    }
}

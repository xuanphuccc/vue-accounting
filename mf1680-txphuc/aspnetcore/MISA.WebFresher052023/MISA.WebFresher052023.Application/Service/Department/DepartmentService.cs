using AutoMapper;
using MISA.WebFresher052023.Domain;
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
        protected override async Task<Department> MapCreateDtoToEntityAsync(DepartmentCreateDto departmentCreateDto)
        {
            // Check trùng mã đơn vị
            await _departmentManager.CheckExistDepartmentCode(departmentCreateDto.DepartmentCode);

            var department = _mapper.Map<Department>(departmentCreateDto);

            // Set thông tin cho bản ghi
            department.DepartmentId = Guid.NewGuid();
            department.CreatedDate = DateTime.Now;
            department.CreatedBy = "txphuc";
            department.ModifiedDate = DateTime.Now;
            department.ModifiedBy = "txphuc";

            return department;
        }

        protected override async Task<Department> MapUpdateDtoToEntityAsync(Guid departmentId, DepartmentUpdateDto departmentUpdateDto)
        {
            // Check đơn vị có tồn tại hay không
            var oldDepartment = await _departmentRepository.GetByIdAsync(departmentId);

            // Check trùng mã đơn vị
            await _departmentManager.CheckExistDepartmentCode(departmentUpdateDto.DepartmentCode, oldDepartment.DepartmentCode);

            var newDepartment = _mapper.Map(departmentUpdateDto, oldDepartment);

            // Set lại ngày sửa đổi bản ghi
            newDepartment.ModifiedDate = DateTime.Now;
            newDepartment.ModifiedBy = "txphuc";

            return newDepartment;
        }

        /// <summary>
        /// Xoá bản ghi theo Id
        /// </summary>
        /// <param name="departmentId">Id của bản ghi</param>
        /// CreatedBy: txphuc (01/08/2023)
        public override async Task<int> DeleteByIdAsync(Guid departmentId)
        {
            // Check bản ghi có tồn tại hay không
            var existDepartment = await _departmentRepository.GetByIdAsync(departmentId);

            // Check bản ghi có phụ thuộc hay không
            var constraintCount = await _departmentRepository.CheckConstraintByIdAsync(existDepartment);
            if (constraintCount > 0)
            {
                throw new ConstraintException(ErrorMessage.ConstraintError, ErrorCode.ConstraintError);
            }

            var result = await _departmentRepository.DeleteByIdAsync(existDepartment);

            return result;
        }

        /// <summary>
        /// Xoá nhiều đối tượng
        /// </summary>
        /// <param name="departmentIds">Danh sách Id của các đối tượng cần xoá</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public override async Task<int> DeleteAsync(List<Guid> departmentIds)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var departments = await _departmentRepository.GetListByIdsAsync(departmentIds);

                var departmentHaveConstraints = await _departmentRepository.CheckListConstraintAsync(departments);

                // Trường hợp list rỗng
                if (departmentIds.Count == 0)
                {
                    throw new NotFoundException(ErrorMessage.NotFound, ErrorCode.NotFound);
                }

                // Trường hợp có bản ghi không tồn tại
                if (departments.ToList().Count < departmentIds.Count)
                {
                    throw new NotFoundException(ErrorMessage.NotFound, ErrorCode.NotFound);
                }

                // Trường hợp có bản ghi có phụ thuộc
                if (departmentHaveConstraints.ToList().Count > 0)
                {
                    var errorMessage = String.Join(", ", departmentHaveConstraints.ToList());

                    throw new ConstraintException(errorMessage, ErrorCode.ConstraintError);
                }

                var result = await _departmentRepository.DeleteAsync(departments);

                await _unitOfWork.CommitAsync();

                return result;
            }
            catch (NotFoundException)
            {
                await _unitOfWork.RollBackAsync();
                throw;
            }
        }
        #endregion
    }
}

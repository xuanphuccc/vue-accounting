using AutoMapper;
using MISA.WebFresher052023.Domain;
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
        #endregion
    }
}

using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentManager _departmentManager;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository, IDepartmentManager departmentManager, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _departmentManager = departmentManager;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ danh sách đơn vị
        /// </summary>
        /// <returns>Danh sách đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return departmentDtos;
        }

        /// <summary>
        /// Lấy đơn vị theo Id
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <returns>Thông tin đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<DepartmentDto> GetByIdAsync(Guid departmentId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);

            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        /// <summary>
        /// Tạo đơn vị mới
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi được thêm</returns>
        public async Task<int> InsertAsync(DepartmentCreateDto departmentCreateDto)
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

            var result = await _departmentRepository.InsertAsync(department);

            return result;
        }

        /// <summary>
        /// Cập nhật đơn vị
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public async Task<int> UpdateAsync(Guid departmentId, DepartmentUpdateDto departmentUpdateDto)
        {
            // Check đơn vị có tồn tại hay không
            var oldDepartment = await _departmentRepository.GetByIdAsync(departmentId);

            // Check trùng mã đơn vị
            await _departmentManager.CheckExistDepartmentCode(departmentUpdateDto.DepartmentCode, oldDepartment.DepartmentCode);

            var newDepartment = _mapper.Map(departmentUpdateDto, oldDepartment);

            // Set lại ngày sửa đổi bản ghi
            newDepartment.ModifiedDate = DateTime.Now;
            newDepartment.ModifiedBy = "txphuc";

            var result = await _departmentRepository.UpdateAsync(newDepartment);

            return result;
        }

        /// <summary>
        /// Xoá một đơn vị
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public async Task<int> DeleteAsync(Guid departmentId)
        {
            // Check đơn vị có tồn tại hay không
            var existDepartment = await _departmentRepository.GetByIdAsync(departmentId);

            var result = await _departmentRepository.DeleteAsync(existDepartment);

            return result;
        }
        #endregion
    }
}

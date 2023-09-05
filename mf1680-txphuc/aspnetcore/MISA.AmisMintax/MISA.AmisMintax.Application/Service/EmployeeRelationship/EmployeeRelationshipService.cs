using AutoMapper;
using MISA.AmisMintax.Domain;
using MISA.AmisMintax.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class EmployeeRelationshipService
        : BaseService<EmployeeRelationship, EmployeeRelationshipModel, EmployeeRelationshipDto, EmployeeRelationshipCreateDto, EmployeeRelationshipUpdateDto>, IEmployeeRelationshipService
    {
        #region Fields
        private readonly IEmployeeRelationshipRepository _employeeRelationshipRepository;
        #endregion

        #region Constructors
        public EmployeeRelationshipService(IEmployeeRelationshipRepository employeeRelationshipRepository, IUnitOfWork unitOfWork, IMapper mapper)
            : base(employeeRelationshipRepository, unitOfWork, mapper)
        {
            _employeeRelationshipRepository = employeeRelationshipRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate nghiệp vụ cho Insert
        /// </summary>
        /// <param name="entityCreateDto">CreateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override Task<EmployeeRelationship> MapCreateDtoToEntityAsync(EmployeeRelationshipCreateDto entityCreateDto)
        {
            var employeeRelationship = _mapper.Map<EmployeeRelationship>(entityCreateDto);

            employeeRelationship.EmployeeRelationshipID = Guid.NewGuid();

            return Task.FromResult(employeeRelationship);
        }

        /// <summary>
        /// Validate nghiệp vụ cho Update
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <param name="entityUpdateDto">UpdateDto</param>
        /// <returns>Entity</returns>
        /// CreatedBy: txphuc (18/07/2023)
        protected override async Task<EmployeeRelationship> MapUpdateDtoToEntityAsync(Guid entityId, EmployeeRelationshipUpdateDto entityUpdateDto)
        {
            // Check thành viên gia đình có tồn tại hay không
            var oldEmployeeRelationship = await _employeeRelationshipRepository.GetByIdAsync(entityId);

            var employeeRelationship = _mapper.Map(entityUpdateDto, oldEmployeeRelationship);

            return employeeRelationship;
        } 
        #endregion
    }
}

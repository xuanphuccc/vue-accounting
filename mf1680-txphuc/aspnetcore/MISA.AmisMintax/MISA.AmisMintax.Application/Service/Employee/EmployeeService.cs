using AutoMapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class EmployeeService : BaseCodeService<Employee, Employee, EmployeeDto, EmployeeCreateDto, EmployeeUpdateDto>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(employeeRepository, unitOfWork, mapper)
        {
        }

        protected override Task<Employee> MapCreateDtoToEntityAsync(EmployeeCreateDto entityCreateDto)
        {
            throw new NotImplementedException();
        }

        protected override Task<Employee> MapUpdateDtoToEntityAsync(Guid entityId, EmployeeUpdateDto entityUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}

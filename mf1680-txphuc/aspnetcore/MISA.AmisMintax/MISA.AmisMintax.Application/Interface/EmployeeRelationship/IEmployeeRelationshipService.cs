using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public interface IEmployeeRelationshipService : 
        IBaseService<EmployeeRelationshipDto, EmployeeRelationshipCreateDto, EmployeeRelationshipUpdateDto>
    {
    }
}

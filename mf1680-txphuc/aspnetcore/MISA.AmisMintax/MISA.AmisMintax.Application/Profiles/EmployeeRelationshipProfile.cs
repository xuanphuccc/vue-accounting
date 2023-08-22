using AutoMapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class EmployeeRelationshipProfile : Profile
    {
        public EmployeeRelationshipProfile() {
        
            // Lấy dữ liệu
            CreateMap<EmployeeRelationship, EmployeeRelationshipDto>();
        }
    }
}

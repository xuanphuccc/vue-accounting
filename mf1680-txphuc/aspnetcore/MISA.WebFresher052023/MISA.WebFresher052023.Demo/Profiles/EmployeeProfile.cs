using AutoMapper;
using MISA.WebFresher052023.Demo.Dtos;
using MISA.WebFresher052023.Demo.Entities;

namespace MISA.WebFresher052023.Demo.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            CreateMap<EmployeeRequestDto, Employee>();
        }
    }
}

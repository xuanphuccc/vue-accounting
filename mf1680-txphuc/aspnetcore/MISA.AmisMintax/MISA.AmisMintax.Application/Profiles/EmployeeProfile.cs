using AutoMapper;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            // Lấy dữ liệu
            CreateMap<Employee, EmployeeDto>();

            // Thêm mới
            CreateMap<EmployeeCreateDto, Employee>();

            // Cập nhật
            CreateMap<EmployeeUpdateDto, Employee>();
        }
    }
}

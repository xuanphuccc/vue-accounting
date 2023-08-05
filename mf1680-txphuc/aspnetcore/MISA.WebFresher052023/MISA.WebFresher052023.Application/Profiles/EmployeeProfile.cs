using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class EmployeeProfile : Profile
    {
        /// <summary>
        /// Cấu hình tự động map các đối tượng
        /// </summary>
        /// CreatedBy: txphuc (16/07/2023)
        public EmployeeProfile()
        {
            // Sử dụng trong trường hợp trả về dữ liệu
            CreateMap<Employee, EmployeeDto>();

            // Trường hợp trả về dữ liệu bao gồm tên của đơn vị và vị trí làm việc
            CreateMap<EmployeeModel, EmployeeDto>();
            
            // Trường hợp trả về file Excel
            CreateMap<EmployeeModel, EmployeeExcelDto>();

            // Trường hợp tạo mới
            CreateMap<EmployeeCreateDto, Employee>();

            // Trường hợp cập nhật
            CreateMap<EmployeeUpdateDto, Employee>();

            // Map dữ liệu filter
            CreateMap<EmployeeFilterDto, EmployeeFilterModel>();
        }
    }
}

using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class DepartmentProfile : Profile
    {
        /// <summary>
        /// Cấu hình tự động map các đối tượng
        /// </summary>
        /// CreatedBy: txphuc (16/07/2023)
        public DepartmentProfile()
        {
            // Trả về dữ liệu
            CreateMap<Department, DepartmentDto>();

            // Trường hợp tạo mới
            CreateMap<DepartmentCreateDto, Department>();

            // Trường hợp cập nhật
            CreateMap<DepartmentUpdateDto, Department>();
        }
    }
}

using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class PositionProfile : Profile
    {
        /// <summary>
        /// Cấu hình tự động map các đối tượng
        /// </summary>
        /// CreatedBy: txphuc (16/07/2023)
        public PositionProfile()
        {
            // Sử dụng trong trường hợp trả về dữ liệu
            CreateMap<Position, PositionDto>();

            // Sử dụng trong trường hợp tạo mới
            CreateMap<PositionCreateDto, Position>();

            // Sử dụng trong trường hợp cập nhật
            CreateMap<PositionUpdateDto, Position>();
        }
    }
}

using AutoMapper;
using MISA.WebFresher052023.Application.Interface;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public abstract class ExcelService<TEntity, TModel, TEntityDto, TEntityExcelInsertDto> : ExcelCore<TEntityDto, TEntityExcelInsertDto>, IExcelService<TEntityDto, TEntityExcelInsertDto>
    {
        #region Fields
        protected readonly IBaseReadOnlyRepository<TEntity, TModel> _baseReadOnlyRepository;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructors
        protected ExcelService(IBaseReadOnlyRepository<TEntity, TModel> baseReadOnlyRepository, IMapper mapper)
        {
            _baseReadOnlyRepository = baseReadOnlyRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Xuất toàn bộ danh sách theo các cột được chỉ định
        /// </summary>
        /// <param name="columns">Danh sách các cột muốn hiển thị</param>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (26/07/2023)
        public async Task<byte[]> ExportAll(IEnumerable<string> columns)
        {
            var entities = await _baseReadOnlyRepository.GetAllAsync();
            var entityDtos = _mapper.Map<IEnumerable<TEntityDto>>(entities);

            var bytes = ExportToExcel(entityDtos, columns);

            return bytes;
        }

        /// <summary>
        /// Xuất danh sách các bản ghi, và theo cột được chỉ định
        /// </summary>
        /// <param name="entityIds">Danh sách Id của các bản ghi muốn xuất</param>
        /// <param name="columns">Danh sách các cột muốn hiển thị</param>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (26/07/2023)
        public async Task<byte[]> ExportList(IEnumerable<Guid> entityIds, IEnumerable<string> columns)
        {
            var entities = await _baseReadOnlyRepository.GetListInfoByIdsAsync(entityIds);
            var entityDtos = _mapper.Map<IEnumerable<TEntityDto>>(entities);

            var bytes = ExportToExcel(entityDtos, columns);

            return bytes;
        }


        #endregion
    }
}

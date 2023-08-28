using AutoMapper;
using MISA.AmisMintax.Application;
using MISA.AmisMintax.Application.Interface;
using MISA.AmisMintax.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Infrastructure
{
    public abstract class ExcelService<TEntity, TEntityDto, TEntityExcelInsertDto> : ExcelCore, IExcelService
    {
        #region Fields
        protected readonly IBaseReadOnlyRepository<TEntity> _baseReadOnlyRepository;
        protected readonly IMapper _mapper;
        #endregion

        #region Constructors
        protected ExcelService(IBaseReadOnlyRepository<TEntity> baseReadOnlyRepository, IMapper mapper)
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
        public async Task<byte[]> ExportAll(IEnumerable<ExcelExportColumnDto> columns)
        {
            var entities = await _baseReadOnlyRepository.GetAllAsync();
            var entityDtos = _mapper.Map<IEnumerable<TEntityDto>>(entities);

            //var bytes = ExportToExcel(entityDtos, columns);

            return null;
        }

        /// <summary>
        /// Xuất danh sách các bản ghi, và theo cột được chỉ định
        /// </summary>
        /// <param name="entityIds">Danh sách Id của các bản ghi muốn xuất</param>
        /// <param name="columns">Danh sách các cột muốn hiển thị</param>
        /// <returns>Mảng bytes của file Excel</returns>
        /// CreatedBy: txphuc (26/07/2023)
        public async Task<byte[]> ExportList(IEnumerable<Guid> entityIds, IEnumerable<ExcelExportColumnDto> columns)
        {
            var entities = await _baseReadOnlyRepository.GetListByIdsAsync(entityIds);
            var entityDtos = _mapper.Map<IEnumerable<TEntityDto>>(entities);

            //var bytes = ExportToExcel(entityDtos, columns);

            return null;
        }
        #endregion
    }
}

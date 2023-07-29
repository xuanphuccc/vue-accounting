using AutoMapper;
using MISA.WebFresher052023.Application;
using MISA.WebFresher052023.Domain;
using MISA.WebFresher052023.Domain.Resources.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public class EmployeeExcelService : ExcelService<Employee, EmployeeModel, EmployeeExcelDto, EmployeeExcelInsertDto>, IEmployeeExcelService
    {
        public EmployeeExcelService(IEmployeeRepository employeeRepository, IMapper mapper) : base(employeeRepository, mapper)
        {
            SheetName = EmployeeResource.ExcelSheetName;
            SheetTitle = EmployeeResource.ExcelSheetTitle;
        }

        /// <summary>
        /// Lấy instance của đối tượng để có thể gán giá trị cho đối tượng generic
        /// </summary>
        /// <returns>Instance của TEntityExcelInsertDto</returns>
        /// CreatedBy: txphuc (29/07/2023)
        protected override EmployeeExcelInsertDto GetEntityInsertDtoInstance()
        {
            return new EmployeeExcelInsertDto();
        }
    }
}

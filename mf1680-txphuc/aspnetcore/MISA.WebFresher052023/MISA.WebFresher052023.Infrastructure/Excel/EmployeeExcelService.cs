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
    public class EmployeeExcelService : ExcelService<Employee, EmployeeModel, EmployeeExcelDto>, IEmployeeExcelService
    {
        public EmployeeExcelService(IEmployeeRepository employeeRepository, IMapper mapper) : base(employeeRepository, mapper)
        {
            SheetName = EmployeeResource.ExcelSheetName;
            SheetTitle = EmployeeResource.ExcelSheetTitle;
        }
    }
}

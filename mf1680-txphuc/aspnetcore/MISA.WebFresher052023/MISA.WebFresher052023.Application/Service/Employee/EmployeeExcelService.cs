using AutoMapper;
using MISA.WebFresher052023.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Application
{
    public class EmployeeExcelService : ExcelService<Employee, EmployeeModel, EmployeeExcelDto>, IEmployeeExcelService
    {
        public EmployeeExcelService(IEmployeeRepository employeeRepository, IMapper mapper) : base(employeeRepository, mapper)
        {
            SheetName = "Nhân viên";
            SheetTitle = "DANH SÁCH NHÂN VIÊN";
        }
    }
}

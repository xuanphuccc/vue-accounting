using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelExportSheetDto
    {
        public string SheetName { get; set; }

        public string SheetTitle { get; set; }

        public string SheetKey { get; set; }

        public List<ExcelExportColumnGroupDto> ColumnGroups { get; set; }

        public List<ExcelExportColumnDto> Columns { get; set; }
    }
}

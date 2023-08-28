using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Application
{
    public class ExcelExportColumnGroupDto
    {
        public string Title { get; set; }

        public int StartColumn { get; set; }

        public int EndColumn { get; set; }

        public string Background { get; set; }
    }
}

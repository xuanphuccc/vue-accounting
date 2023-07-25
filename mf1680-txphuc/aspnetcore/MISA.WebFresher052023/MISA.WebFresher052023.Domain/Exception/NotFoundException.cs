using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class NotFoundException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, ErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

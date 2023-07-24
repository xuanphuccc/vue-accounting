using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class ConflictException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public ConflictException(string message) : base(message) { }

        public ConflictException(string messsage, ErrorCode errorCode) : base(messsage)
        {
            ErrorCode = errorCode;
        }
    }
}

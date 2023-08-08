using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class MaxCodeException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public MaxCodeException() { }

        public MaxCodeException(string message) : base(message) { }

        public MaxCodeException(string message, ErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

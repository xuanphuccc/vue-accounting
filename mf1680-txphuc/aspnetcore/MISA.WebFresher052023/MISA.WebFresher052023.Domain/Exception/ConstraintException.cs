﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public class ConstraintException : Exception
    {
        public ErrorCode ErrorCode { get; set; }

        public ConstraintException() { }

        public ConstraintException(string message) : base(message) { }

        public ConstraintException(string message, ErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}

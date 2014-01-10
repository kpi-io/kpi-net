using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPI.Client.Exceptions
{
    public class KPIException : Exception
    {
        public int Code { get; private set; }

        public KPIException(int code, string message)
            : this(code, message, null)
        {

        }

        public KPIException(int code, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Code = code;
        }
    }
}

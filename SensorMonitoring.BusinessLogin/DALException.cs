using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.BusinessLogin
{
    public class DALException : Exception
    {
        public DALException() : base() { }
        public DALException(string message) : base() { }
    }
}
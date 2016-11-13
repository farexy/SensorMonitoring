using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.SL.DTO
{
    public abstract class BaseDTO
    {
        public abstract object[] Keys { get; }
        internal abstract string pathToActions { get; }

    }
}
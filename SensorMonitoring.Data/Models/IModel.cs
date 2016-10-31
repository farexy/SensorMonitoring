using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.Models
{
    public abstract class IModel
    {
        //void Copy(IModel model);
        public abstract object[] Keys { get; }

    }
}
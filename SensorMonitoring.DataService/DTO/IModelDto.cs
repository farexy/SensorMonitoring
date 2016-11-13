using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SensorMonitoring.Data.DTO
{
    [DataContract]
    public abstract class IModelDto
    {
        //void Copy(IModel model);
        public abstract object[] Keys { get; }

    }
}
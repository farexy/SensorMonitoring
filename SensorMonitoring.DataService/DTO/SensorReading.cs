using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SensorMonitoring.Data.Models
{
        [DataContract]
    public class SensorReadingDto : IModelDto
    {
            [DataMember]
        public int UserId { set; get; }
            [DataMember]
        public DateTime DateTime { set; get; }
            [DataMember]
        public double Value { set; get; }

        public SensorReadingDto(SensorReading sensorReading)
        {
            UserId = sensorReading.UserId;
            DateTime = sensorReading.DateTime;
            Value = sensorReading.Value;
        }

            public SensorReading ToEntity()
            {
                SensorReading sensorReading = new SensorReading();
                sensorReading.UserId = UserId;
                sensorReading.DateTime = DateTime;
                sensorReading.Value = Value;
                return sensorReading;
            }

        public override object[] Keys
        {
            get { return new object[] { UserId, DateTime }; }
        }
    }
}
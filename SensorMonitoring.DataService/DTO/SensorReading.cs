using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SensorMonitoring.Data.Models;

namespace SensorMonitoring.Data.DTO
{
    [DataContract]
    public class SensorReadingDto : IModelDto
    {
        [DataMember]
        public int SensorId { set; get; }
        [DataMember]
        public DateTime DateTime { set; get; }
        [DataMember]
        public double Value { set; get; }

        public SensorReadingDto(SensorReading sensorReading)
        {
            SensorId = sensorReading.SensorId;
            DateTime = sensorReading.DateTime;
            Value = sensorReading.Value;
        }

            public SensorReading ToEntity()
            {
                SensorReading sensorReading = new SensorReading();
                sensorReading.SensorId = SensorId;
                sensorReading.DateTime = DateTime;
                sensorReading.Value = Value;
                return sensorReading;
            }

        public override object[] Keys
        {
            get { return new object[] { SensorId, DateTime }; }
        }
    }
}
using System;

namespace BLL.Loader.DTO
{
    public class SensorReadingDTO : BaseDTO
    {
        public int SensorId { set; get; }
        public DateTime DateTime { set; get; }
        public double Value { set; get; }
        public SensorDTO Sensor { set; get; }


        internal override string pathToActions { get { return "sensorreading"; } }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SensorReadingTable
    {
        static Dictionary<int, double> sensorReadings = new Dictionary<int, double>();

        public static void UpdateReading(int sensorId, double value)
        {
            if(sensorReadings.ContainsKey(sensorId))
            {
                sensorReadings[sensorId] = value;
            }
            else
            {
                sensorReadings.Add(sensorId, value);
            }
        }

        public static double GetReading(int sensorId)
        {
            if (sensorReadings.ContainsKey(sensorId))
                return sensorReadings[sensorId];
            else
                return 0.0;
        }
    }
}

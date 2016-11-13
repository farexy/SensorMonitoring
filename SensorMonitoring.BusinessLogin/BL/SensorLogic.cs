using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SensorMonitoring.BusinessLogin.SensorServiceReference1;
using SensorMonitoring.Data.DTO;

namespace SensorMonitoring.BusinessLogin.BL
{
    public class SensorLogic : IBaseLogic<SensorDto>
    {
        private  SensorServiceReference1.DataServiceOf_SensorDtoClient serviceOfSensor = new DataServiceOf_SensorDtoClient();

        public SensorDto Get(object[] keys)
        {
            SensorDto d = serviceOfSensor.GetItem(keys);
            return d;
        }

        public void Create(SensorDto sensor)
        {
            serviceOfSensor.AddItem(sensor);
        }

        public void Update(SensorDto sensor)
        {
            serviceOfSensor.AddItem(sensor);
        }

        public void Delete(object[] keys)
        {
            //serviceOfSensor.
        }

        public bool IsValid(string name, string password)
        {
            string decryptPassword = Encrypter.Decrypt(password);
            return true;
        }
    }
}
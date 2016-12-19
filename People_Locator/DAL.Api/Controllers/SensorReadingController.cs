using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using DAL.Repositories;
using SensorMonitoring.Data.Models;

namespace DAL.Api.Controllers
{
    public class SensorReadingController : ApiController
    {
        private IRepository<SensorReading> repo = DependencyResolver.Current.GetService<IRepository<SensorReading>>();

        [System.Web.Http.HttpPost]
        public bool CreateSensorReading(SensorReading model)
        {
            if (model == null) { return false; }

            // exception filter will catch exceptions
            repo.Add(model);
            repo.SaveChanges();

            return true;
        }

        public IEnumerable<SensorReading> GetSensorReading()
        {
            return repo.Find(s => true);
        }

        [System.Web.Http.HttpPut]
        public bool UpdateSensor(SensorReading model)
        {
            if (model == null) { return false; }

            repo.Update(model);
            repo.SaveChanges();

            return true;
        }

        [System.Web.Http.HttpDelete]
        public bool DeleteSubscription(DateTime dateTime, int sensorId)
        {
            //bool result = repo.Delete(new object[] { dateTime, sensorId });
            bool result = repo.Delete(sensorId);

            if (result)
            {
                repo.SaveChanges();
            }

            return result;
        }
    }
}

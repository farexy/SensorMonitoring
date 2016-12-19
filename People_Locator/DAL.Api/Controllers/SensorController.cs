using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using DAL.Repositories;
using SensorMonitoring.Data.Models;

namespace DAL.Api.Controllers
{
    public class SensorController : ApiController
    {
        private IRepository<Sensor> repo = DependencyResolver.Current.GetService<IRepository<Sensor>>();

        [System.Web.Http.HttpPost]
        public bool CreateSensor(Sensor model)
        {
            if (model == null) { return false; }

            // exception filter will catch exceptions
            repo.Add(model);
            repo.SaveChanges();

            return true;
        }

        public IEnumerable<Sensor> GetSensorsByMasterId(int userId)
        {
            return repo.Find(s => s.UserId == userId);
        } 

        [System.Web.Http.HttpGet]
        public Sensor GetSensor(int id)
        {
            return repo.Find(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<Sensor> GetSensors()
        {
            return repo.Find(s => true);
        }
            
            [System.Web.Http.HttpPut]
        public bool UpdateSensor(Sensor model)
        {
            if (model == null) { return false; }

            repo.Update(model);
            repo.SaveChanges();

            return true;
        }

        [System.Web.Http.HttpDelete]
        public bool DeleteSensor(object[] ids)
        {
            //bool result = repo.Delete(new object[] {id});
            bool result = repo.Delete(ids);

            if (result)
            {
                repo.SaveChanges();
            }

            return result;
        }

        [System.Web.Http.HttpDelete]
        public bool DeleteSensor(int id)
        {
            //bool result = repo.Delete(new object[] {id});
            bool result = repo.Delete(id);

            if (result)
            {
                repo.SaveChanges();
            }

            return result;
        }
    }
}

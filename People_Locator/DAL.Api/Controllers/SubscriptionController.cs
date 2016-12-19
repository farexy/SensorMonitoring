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
    public class SubscriptionController : ApiController
    {
        private IRepository<Subscription> repo = DependencyResolver.Current.GetService<IRepository<Subscription>>();

        [System.Web.Http.HttpPost]
        public bool CreateSubscription(Subscription model)
        {
            if (model == null) { return false; }

            // exception filter will catch exceptions
            repo.Add(model);
            repo.SaveChanges();

            return true;
        }

        public IEnumerable<Subscription> GetSubscriptions()
        {
            return repo.Find(s => true);
        }

        public Subscription GetSubscription(int userId, int sensorId)
        {
            return repo.Find(s => s.SensorId == sensorId && s.UserId == userId).FirstOrDefault();
        }

        [System.Web.Http.HttpPut]
        public bool UpdateSensor(Subscription model)
        {
            if (model == null) { return false; }

            repo.Update(model);
            repo.SaveChanges();

            return true;
        }

        [System.Web.Http.HttpDelete]
        public bool DeleteSubscription([FromUri]int[] ids)
        {
            //bool result = repo.Delete(new object[] {userId, sensorId });
            bool result = repo.Delete(new object[] { ids[0], ids[1]});
            if (result)
            {
                repo.SaveChanges();
            }

            return result;
        }

    }
}

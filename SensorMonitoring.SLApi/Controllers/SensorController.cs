using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SensorMonitoring.SL.DTO;
using SL.Loader;

namespace SensorMonitoring.SLApi.Controllers
{
    public class SensorController : ApiController
    {

        private ILoader<SensorDTO> loader = (ILoader<SensorDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<SensorDTO>));
        public SensorDTO Get(int id)
        {
            SensorDTO r = loader.LoadById(new object[] {id});
            return r;
        }
    }
}

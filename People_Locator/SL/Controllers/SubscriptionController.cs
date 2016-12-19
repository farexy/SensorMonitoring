using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;
using BLL.Loader;
using BLL.Loader.DTO;
using SL.Models;

namespace SL.Controllers
{
    public class SubscriptionController : ApiController
    {
        private ILoader<SubscriptionDTO> loader = (ILoader<SubscriptionDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<SubscriptionDTO>));


        [System.Web.Http.HttpPost]
        public CUDResponseView CreateSubscription(SubscriptionViewModel model)
        {
            try
            {
                ILoader<SensorDTO> sensorLoader = (ILoader<SensorDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<SensorDTO>));
                SensorDTO sensor = sensorLoader.LoadById(model.SensorId);
                if (sensor != null && sensor.Password == model.Password)
                    loader.PostItem(new SubscriptionDTO() { SensorId = model.SensorId, UserId = model.UserId});
                else
                {
                    throw new ValidationException("Password is not correct");
                }
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }
            return CUDResponseView.BuildSuccessResponse();
        }

        public IEnumerable<SensorDTO> GetSensorsByUserId(int userId)
        {
            IEnumerable<int> ids = loader.LoadAll().Where(s => s.UserId == userId).Select(s => s.SensorId);
            ILoader<SensorDTO> sensorLoader = (ILoader<SensorDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<SensorDTO>));
            return sensorLoader.LoadAll().Where(s => ids.Contains(s.Id));
            // return service.Find(s => s.UserId == userId).Select(s => s.Sensor);
        }

        public SubscriptionDTO GetSubscription(int userId, int sensorId)
        {
            return loader.LoadAll().FirstOrDefault(s => s.SensorId == sensorId && s.UserId == userId);
        }

        [System.Web.Http.HttpPut]
        public CUDResponseView UpdateSensor(SubscriptionDTO model)
        {
            try
            {
                loader.PutItem(model);
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }
            return CUDResponseView.BuildSuccessResponse();
        }

        [System.Web.Http.HttpGet]
        [Route("api/subscription/delete")]
        public CUDResponseView DeleteSubscription([FromUri]int sensorId, [FromUri]int userId)
        {
            try
            {
                loader.DeleteItem(new object[] { userId, sensorId });
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }

            return CUDResponseView.BuildSuccessResponse();

        }

    }
}

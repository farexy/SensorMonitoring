using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;
using BLL.Loader;
using BLL.Loader.DTO;

namespace SL.Controllers
{
    public class SubscriptionController : ApiController
    {
        private ILoader<SubscriptionDTO> loader = (ILoader<SubscriptionDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<SubscriptionDTO>));


        [System.Web.Http.HttpPost]
        public CUDResponseView CreateSubscription(SubscriptionDTO model)
        {
            try
            {
                loader.PostItem(model);
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }
            return CUDResponseView.BuildSuccessResponse();
        }

        public IEnumerable<SubscriptionDTO> GetSensorsByUserId(int userId)
        {
            return null;
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

        [System.Web.Http.HttpDelete]
        public CUDResponseView DeleteSubscription(int userId, int sensorId)
        {
            try
            {
                //loader.DeleteItem(new object[] { userId, sensorId });
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }

            return CUDResponseView.BuildSuccessResponse();

        }

    }
}

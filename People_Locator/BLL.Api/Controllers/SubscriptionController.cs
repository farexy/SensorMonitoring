using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using BLL.Loader.DTO;
using BLL.Services;
using BLL.Validation;

namespace BLL.Api.Controllers
{
    public class SubscriptionController : ApiController
    {
        private IService<SubscriptionDTO> service = DependencyResolver.Current.GetService<IService<SubscriptionDTO>>();

        [System.Web.Http.HttpPost]
        public CUDResponseView CreateSubscription(SubscriptionDTO model)
        {
            try
            {
                service.Create(model);
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
            return service.Find(s => s.SensorId == sensorId && s.UserId == userId).FirstOrDefault();
        }

        [System.Web.Http.HttpPut]
        public CUDResponseView UpdateSensor(SubscriptionDTO model)
        {
            try
            {
                service.Update(model);
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
                service.Delete(new object[] { userId, sensorId });
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }

            return CUDResponseView.BuildSuccessResponse();

        }

    }
}

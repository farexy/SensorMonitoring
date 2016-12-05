using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Mvc;
using BLL.Loader;
using BLL.Loader.DTO;

namespace SL.Controllers
{
    public class SensorReadingController : ApiController
    {
        private ILoader<SensorReadingDTO> loader = (ILoader<SensorReadingDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<SensorReadingDTO>));

        [System.Web.Http.HttpPost]
        public CUDResponseView CreateSensorReading(SensorReadingDTO model)
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

        public SensorReadingDTO GetSensorReading(int id)
        {
            return loader.LoadById(id);
        }

        [System.Web.Http.HttpPut]
        public CUDResponseView UpdateSensor(SensorReadingDTO model)
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
        public CUDResponseView DeleteSubscription(int id)
        {
            try
            {
                loader.DeleteItem(id);
            }
            catch (ValidationException e)
            {
                return CUDResponseView.BuildErrorResponse(e.Message);
            }
            return CUDResponseView.BuildSuccessResponse();

        }
    }
}

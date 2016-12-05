using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using BLL.Loader;
using BLL.Loader.DTO;

namespace SL.Controllers
{
    public class SensorController : ApiController
    {
        private ILoader<SensorDTO> loader = (ILoader<SensorDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<SensorDTO>));

        [System.Web.Http.HttpPost]
        public CUDResponseView CreateSensor(SensorDTO model)
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

        public IEnumerable<SensorDTO> GetSensorsByMasterId(int userId)
        {
            return loader.LoadAll().Where(s => s.UserId == userId);
        } 

        public SensorDTO GetSensor(int id)
        {
            return loader.LoadById(id);
        }

        [System.Web.Http.HttpPut]
        public CUDResponseView UpdateSensor(SensorDTO model)
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
        public CUDResponseView DeleteSensor(int id)
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

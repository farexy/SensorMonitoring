using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using BLL.Loader.DTO;
using BLL.Services;
using BLL.Validation;

namespace DAL.Api.Controllers
{
    public class SensorController : ApiController
    {
        private IService<SensorDTO> service = DependencyResolver.Current.GetService<IService<SensorDTO>>();

        [System.Web.Http.HttpPost]
        public CUDResponseView CreateSensor(SensorDTO model)
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

        public SensorDTO Get(int id)
        {
            return service.Find(s => s.Id == id).FirstOrDefault();
        }

        public IEnumerable<SensorDTO> GetSensors()
        {
            return service.Find(s => true);
        }


        [System.Web.Http.HttpPut]
        public CUDResponseView UpdateSensor(SensorDTO model)
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
        public CUDResponseView DeleteSensor(int id)
        {
            try
            {
                 service.Delete(id);
            }
            catch (ValidationException e)
            {
                return CUDResponseView.BuildErrorResponse(e.Message);
            }
            return CUDResponseView.BuildSuccessResponse();
        }


    }
}

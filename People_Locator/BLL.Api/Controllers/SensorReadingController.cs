using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BLL.Loader.DTO;
using BLL.Services;
using BLL.Validation;

namespace DAL.Api.Controllers
{
    public class SensorReadingController : ApiController
    {
        private IService<SensorReadingDTO> service = DependencyResolver.Current.GetService<IService<SensorReadingDTO>>();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/sensorreading/add_value")]
        public CUDResponseView AddValue([FromUri]double value, [FromUri]int sensorId)
        {
            /*SensorReadingDTO reading = service.Find(sr => sr.SensorId == sensorId).FirstOrDefault();
            if(reading == null || DateTime.Now - reading.DateTime > TimeSpan.FromHours(1))
                service.Create(new SensorReadingDTO()
                {
                    DateTime = DateTime.Now,
                    SensorId = sensorId,
                    Value = value
                });*/
            SensorReadingTable.UpdateReading(sensorId, value);
            return CUDResponseView.BuildSuccessResponse();
        }

        [System.Web.Http.HttpGet]
        public SensorReadingDTO GetLastReading(int id)
        {
            return new SensorReadingDTO()
            {
                Value = SensorReadingTable.GetReading(id)

            };
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<SensorReadingDTO> GetSensorReadings()
        {
            return service.Find(sr => true);
        }
            
        [System.Web.Http.HttpPost]
        public CUDResponseView CreateSensorReading(SensorReadingDTO model)
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

        public SensorReadingDTO GetSensorReading(DateTime dateTime, int sensorId)
        {
            return service.Find(s => s.SensorId == sensorId && s.DateTime == dateTime).FirstOrDefault();
        }

        [System.Web.Http.HttpPut]
        public CUDResponseView UpdateSensor(SensorReadingDTO model)
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
        public CUDResponseView DeleteSubscription(DateTime dateTime, int sensorId)
        {
            try
            {
                service.Delete(new object[] {dateTime, sensorId});
            }
            catch (ValidationException e)
            {
                return CUDResponseView.BuildErrorResponse(e.Message);
            }
            return CUDResponseView.BuildSuccessResponse();

        }
    }
}

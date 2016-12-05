﻿using System;
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

        public IEnumerable<SensorDTO> GetSensorsByMasterId(int userId)
        {
            return service.Find(s => s.UserId == userId);
        } 

        public SensorDTO GetSensor(int id)
        {
            return service.Find(s => s.Id == id).FirstOrDefault();
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
                service.Delete(new object[] {id});
            }
            catch (ValidationException e)
            {
                return CUDResponseView.BuildErrorResponse(e.Message);
            }
            return CUDResponseView.BuildSuccessResponse();
        }


    }
}
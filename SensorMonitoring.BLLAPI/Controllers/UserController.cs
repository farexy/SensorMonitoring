using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SensorMonitoring.BLLAPI.Controllers
{
    public class UserController : ApiController
    {
        private IUserService service = DependencyResolver.Current.GetService<IUserService>();

        private CUDResponseView registerUser(UserDTO user)
        {
            try
            {
                service.Register(user);
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }
            return CUDResponseView.BuildSuccessResponse();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/user/login")]
        public UserDTO Login(string login, string password) => service.Login(login, password);

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/user/register")]
        public CUDResponseView Register(UserDTO user)
        {
            return this.registerUser(user);
        }

        [System.Web.Http.HttpPost]
        public CUDResponseView CreateUser(UserDTO user)
        {
            return this.registerUser(user);
        }

        public IEnumerable<UserDTO> GetAll() => service.Find(user => true);

        [System.Web.Http.HttpPut]
        public CUDResponseView UpdateItem(UserDTO user)
        {
            try
            {
                service.Update(user);
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }
            return CUDResponseView.BuildSuccessResponse();
        }

        [System.Web.Http.HttpDelete]
        public CUDResponseView DeleteItem(int id)
        {
            try
            {
                service.Delete(id);
            }
            catch (ValidationException ex)
            {
                return CUDResponseView.BuildErrorResponse(ex.Message);
            }

            return CUDResponseView.BuildSuccessResponse();
        }
    }
}

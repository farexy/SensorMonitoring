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
    public class UserController : ApiController
    {
        private ILoader<UserDTO> loader = (ILoader<UserDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<UserDTO>));

        [HttpGet]
        public UserDTO Get(int id)
        {
            return loader.LoadById(new object[] {id});
        }

        [Route("api/user/register")]
        [HttpPost]
        public CUDResponseView Register(UserDTO user)
        {
            if (user == null)
            {
                return null;
            }
            return loader.PostItem(user);
        }

        [HttpPut]
        public CUDResponseView UpdateUser(UserDTO user)
        {
            if (user == null) { return null; }

            return loader.PutItem(user);
        }

        [HttpDelete]
        public CUDResponseView DeleteUser(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return loader.DeleteItem(id);
        }
    }
}

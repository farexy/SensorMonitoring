using BLL.Loader;
using BLL.Loader.DTO;
using SL.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace SL.Controllers
{
    public class UserController : ApiController
    {
        private ILoader<UserDTO> loader = (ILoader<UserDTO>)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(ILoader<UserDTO>));

        [Route("api/user/login")]
        [HttpPost]
        public UserDTO Login(UserDTO user)
        {
            string email = user.Email;
            string password = user.Password;

            if (email == null || password == null)
            {
                return new UserDTO();
            }

            UserDTO dbUser = loader.LoadAll().FirstOrDefault(u => u.Email == email);

            return dbUser;
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

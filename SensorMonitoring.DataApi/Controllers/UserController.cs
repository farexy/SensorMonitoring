using SensorMonitoring.Data.DAL;
using SensorMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SensorMonitoring.DataApi.Controllers
{
    public class UserController : ApiController
    {
        private IRepository<User> repo = new Repository<User>();

        public User GetUserById(int id)
        {
            return repo.Get(new object[]{id});
        }
        /*
        public IEnumerable<User> GetUsers()
        {
            return repo.GetUsers();
        }*/

        [System.Web.Http.HttpPost]
        public bool CreateUser(User user)
        {
            if (user == null) { return false; }

            // exception filter will catch exceptions
            repo.Add(user);

            return true;
        }

        [System.Web.Http.HttpPut]
        public bool UpdateUser(User user)
        {
            if (user == null) { return false; }

            repo.Update(user);

            return true;
        }

        [System.Web.Http.HttpDelete]
        public bool DeleteUser(int id)
        {
            bool result = repo.Delete(new object[]{id});

            if (result)
            {
            }

            return result;
        }
    }
}

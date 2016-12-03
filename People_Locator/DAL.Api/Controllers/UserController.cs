using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Repositories;
using System.Web.Mvc;
using SensorMonitoring.Data.Models;

namespace DAL.Api.Controllers
{
    public class UserController : ApiController
    {
        private IRepository<User> repo = DependencyResolver.Current.GetService<IRepository<User>>();

        public User GetUser(string email)
        {
            return repo.Find(user => user.Email == email).FirstOrDefault();
        }
        

        public User GetUserById(int id)
        {
            return repo.Find(user => user.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers() 
        {
            return repo.Find(user => true);
        }

        [System.Web.Http.HttpPost]
        public bool CreateUser(User user)
        {
            if (user == null) { return false; }

            // exception filter will catch exceptions
            repo.Add(user);
            repo.SaveChanges();

            return true;
        }

        [System.Web.Http.HttpPut]
        public bool UpdateUser(User user)
        {
            if (user == null) { return false; }

            repo.Update(user);
            repo.SaveChanges();

            return true;
        }

        [System.Web.Http.HttpDelete]
        public bool DeleteUser(int id)
        {
            bool result =repo.Delete(id);

            if (result)
            {
                repo.SaveChanges();
            }

            return result;
        }
    }
}

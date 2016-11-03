using SensorMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.DAL
{
    public class UserRepository : Repository<User>
    {

        public User GetUser(int? id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Users;
        } 

        public void AddUser(User user)
        {
            db.Users.Add(user);
        }
    }
}
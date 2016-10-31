using SensorMonitoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.DAL
{
    public class UserRepository
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static User GetUser(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public static void AddUser(User user)
        {
            db.Users.Add(user);
        }
    }
}
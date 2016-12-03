using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.Models
{
    public class User : IModel
    {
        public int Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public virtual ICollection<Sensor> Sensors { set; get; }
        public virtual ICollection<Subscription> Subscriptions { set; get; }

        public void Copy(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            Password = user.Password;
            Sensors = user.Sensors;
            Subscriptions = user.Subscriptions;
        }

        public override object[] Keys
        {
            get
            {
                return new object[] { this.Id };
            }
        }
    }
}
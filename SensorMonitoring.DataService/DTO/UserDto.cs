using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SensorMonitoring.Data.Models
{
    [DataContract]
    public class UserDto : IModelDto
    {
        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string FullName { set; get; }
        [DataMember]
        public string Email { set; get; }
        [DataMember]
        public string Password { set; get; }
        ///public virtual ICollection<Sensor> Sensors { set; get; }
        //public virtual ICollection<SubscriptionDto> Subscriptions { set; get; }

        public UserDto(User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            Email = user.Email;
            Password = user.Password;
        }

        public User ToEntity()
        {
            User user = new User();
            user.Id = Id;
            user.Email = Email;
            user.FullName = FullName;
            user.Password = Password;
            return user;
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
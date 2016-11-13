using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SensorMonitoring.Data.Models;

namespace SensorMonitoring.Data.DTO
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
            user = new User() {Email = "s", FullName = "w3", Password = "ww", Id = 2};
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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SensorMonitoring.Data.Models
{
        [DataContract]
    public class SubscriptionDto : IModelDto
    {
        [DataMember]
        public int UserId { set; get; }
            [DataMember]
        public UserDto User { set; get; }
            [DataMember]
        public int SensorId { set; get; }
            [DataMember]
        public SensorDto Sensor { set; get; }

        public override object[] Keys { get { return new object[] { UserId, SensorId }; } }


        public SubscriptionDto(Subscription subscription)
        {
            UserId = subscription.UserId;
            User = new UserDto(subscription.User);
            SensorId = subscription.SensorId;
            Sensor = new SensorDto(subscription.Sensor);
        }

            public Subscription ToEntity()
            {
                Subscription subscription = new Subscription();
                subscription.UserId = UserId;
                subscription.User = User.ToEntity();
                subscription.SensorId = SensorId;
                subscription.Sensor = Sensor.ToEntity();
                return subscription;
            }
        }
}
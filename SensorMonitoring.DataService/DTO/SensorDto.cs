using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using SensorMonitoring.Data.DAL;
using SensorMonitoring.Data.Models;

namespace SensorMonitoring.Data.DTO
{
    [DataContract]
    public class SensorDto : IModelDto
    { 
        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string Name { set; get; }
        [DataMember]
        public string Place { set; get; }
        [DataMember]
        public string Substance { set; get; }
        [DataMember]
        public double Limit { set; get; }
        [DataMember]
        public string Dimension { set; get; }
        [DataMember]
        public string Password { set; get; }
        
        [DataMember]
        public int UserId { set; get; }
        //public virtual ICollection<SubscriptionDto> Subscriptions { set; get; }
        //public virtual ICollection<SensorReadingDto> Readings { set; get; }

        public override object[] Keys { get { return new object[] { this.Id }; } }

        public SensorDto(Sensor sensor)
        {
            //UserRepository repo = new UserRepository();
            Id = sensor.Id;
            Name = sensor.Name;
            Place = sensor.Place;
            Substance = sensor.Substance;
            Limit = sensor.Limit;
            Dimension = sensor.Dimension;
            Password = sensor.Password;
            UserId = sensor.UserId;
            //Master = new UserDto(repo.GetUser(sensor.UserId));
        }

        public Sensor ToEntity()
        {
            Sensor sensor = new Sensor();
            sensor.Id = Id;
            sensor.Name = Name;
            sensor.Place = Place ;
            sensor.Substance = Substance;
            sensor.Limit = Limit;
            sensor.Dimension = Dimension;
            sensor.Password = Password;
            sensor.UserId = UserId;
            //sensor.Master = Master.ToEntity();
            return sensor;
        }
    }
}
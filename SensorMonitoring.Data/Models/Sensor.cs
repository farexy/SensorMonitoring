using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.Models
{
    public class Sensor : IModel
    { 
        public int Id { set; get; }
        public string Name { set; get; }
        public string Place { set; get; }
        public string Substance { set; get; }
        public double Limit { set; get; }
        public string Dimension { set; get; }
        public string Password { set; get; }
        //[ForeignKey("UserId")]
        public User Master { set; get; }
        public virtual ICollection<Subscription> Subscriptions { set; get; }
        public virtual ICollection<SensorReading> Readings { set; get; }

        public override object[] Keys { get { return new object[] { this.Id }; } }
    }
}
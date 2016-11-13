using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SensorMonitoring.SL.DTO
{
    public class SensorDTO : BaseDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Place { set; get; }
        
        public string Substance { set; get; }
        public double Limit { set; get; }
        public string Dimension { set; get; }
        public string Password { set; get; }

        public int UserId { set; get; }
        //public virtual ICollection<SubscriptionDto> Subscriptions { set; get; }
        //public virtual ICollection<SensorReadingDto> Readings { set; get; }

        public override object[] Keys { get { return new object[] { this.Id }; } }

        internal override string pathToActions
        {
            get { return "servise"; }
        }
    }
}
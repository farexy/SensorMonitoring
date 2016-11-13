using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.Models
{
    public class Subscription : IModel
    {
        [Key, Column(Order = 1)]
        public int UserId { set; get; }
        public virtual User User { set; get; }
        [Key, Column(Order = 2)]
        public int SensorId { set; get; }
        public virtual Sensor Sensor { set; get; }

        public override object[] Keys { get { return new object[] { UserId, SensorId }; } }
    }
}
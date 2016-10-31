using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SensorMonitoring.Data.Models
{
    public class SensorReading : IModel
    {
        [Key, Column(Order = 1)]
        public int UserId { set; get; }
        [Key, Column(Order = 2)]
        public DateTime DateTime { set; get; }
        public double Value { set; get; }

        public override object[] Keys
        {
            get { return new object[] { UserId, DateTime }; }
        }
    }
}
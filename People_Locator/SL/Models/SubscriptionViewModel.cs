using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SL.Models
{
    public class SubscriptionViewModel
    {
        public int UserId { set; get; }
        public int SensorId { set; get; }
        public string Password { set; get; }
    }
}
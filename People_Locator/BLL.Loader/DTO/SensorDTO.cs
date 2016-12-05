using System.Collections.Generic;

namespace BLL.Loader.DTO
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
        public UserDTO Master { set; get; }
        public ICollection<SubscriptionDTO> Subscriptions { set; get; }
        public  ICollection<SensorReadingDTO> Readings { set; get; }

        internal override string pathToActions { get { return "sensor"; } }
    }
}
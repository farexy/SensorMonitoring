namespace BLL.Loader.DTO
{
    public class SubscriptionDTO : BaseDTO
    {
        public int UserId { set; get; }
        public UserDTO User { set; get; }
        public int SensorId { set; get; }
        public virtual SensorDTO Sensor { set; get; }

        internal override string pathToActions { get { return "subscription"; } }
    }
}
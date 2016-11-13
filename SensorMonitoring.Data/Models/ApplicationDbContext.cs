namespace SensorMonitoring.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public DbSet<User> Users { set; get; }
        public DbSet<Sensor> Sensors { set; get; }
        public DbSet<Subscription> Subscriptions { set; get; }
        public DbSet<SensorReading> Readings { set; get; }
    }
}

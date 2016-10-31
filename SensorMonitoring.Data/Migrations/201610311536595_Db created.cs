namespace SensorMonitoring.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbcreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SensorReadings",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        Sensor_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.DateTime })
                .ForeignKey("dbo.Sensors", t => t.Sensor_Id)
                .Index(t => t.Sensor_Id);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Place = c.String(),
                        Substance = c.String(),
                        Limit = c.Double(nullable: false),
                        Dimension = c.String(),
                        Password = c.String(),
                        Master_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Master_Id)
                .Index(t => t.Master_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        SensorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.SensorId })
                .ForeignKey("dbo.Sensors", t => t.SensorId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SensorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SensorReadings", "Sensor_Id", "dbo.Sensors");
            DropForeignKey("dbo.Subscriptions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Subscriptions", "SensorId", "dbo.Sensors");
            DropForeignKey("dbo.Sensors", "Master_Id", "dbo.Users");
            DropIndex("dbo.Subscriptions", new[] { "SensorId" });
            DropIndex("dbo.Subscriptions", new[] { "UserId" });
            DropIndex("dbo.Sensors", new[] { "Master_Id" });
            DropIndex("dbo.SensorReadings", new[] { "Sensor_Id" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Users");
            DropTable("dbo.Sensors");
            DropTable("dbo.SensorReadings");
        }
    }
}

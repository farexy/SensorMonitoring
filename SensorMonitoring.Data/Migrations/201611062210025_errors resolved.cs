namespace SensorMonitoring.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class errorsresolved : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SensorReadings",
                c => new
                    {
                        SensorId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.SensorId, t.DateTime })
                .ForeignKey("dbo.Sensors", t => t.SensorId, cascadeDelete: true)
                .Index(t => t.SensorId);
            
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                .ForeignKey("dbo.Sensors", t => t.SensorId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.SensorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SensorReadings", "SensorId", "dbo.Sensors");
            DropForeignKey("dbo.Subscriptions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Subscriptions", "SensorId", "dbo.Sensors");
            DropForeignKey("dbo.Sensors", "UserId", "dbo.Users");
            DropIndex("dbo.Subscriptions", new[] { "SensorId" });
            DropIndex("dbo.Subscriptions", new[] { "UserId" });
            DropIndex("dbo.Sensors", new[] { "UserId" });
            DropIndex("dbo.SensorReadings", new[] { "SensorId" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Users");
            DropTable("dbo.Sensors");
            DropTable("dbo.SensorReadings");
        }
    }
}

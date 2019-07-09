namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Day = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Image = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Duration = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Capacity = c.String(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        TrainersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainersId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.TrainersId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 60),
                        Number = c.String(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Address = c.String(),
                        ScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .Index(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.String(),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Image = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Tags = c.String(),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Cupons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Image = c.String(),
                        Description = c.String(),
                        startDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Image = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 60),
                        Number = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Pincode = c.Int(nullable: false),
                        Fax = c.String(),
                        Website = c.String(),
                        Conditions = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Google = c.String(),
                        Skype = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Galleries", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Users", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Schedules", "TrainersId", "dbo.Trainers");
            DropForeignKey("dbo.Schedules", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Schedules", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Calendars", "PackageId", "dbo.Packages");
            DropIndex("dbo.News", new[] { "PackageId" });
            DropIndex("dbo.Galleries", new[] { "PackageId" });
            DropIndex("dbo.Users", new[] { "ScheduleId" });
            DropIndex("dbo.Schedules", new[] { "TrainersId" });
            DropIndex("dbo.Schedules", new[] { "RoomId" });
            DropIndex("dbo.Schedules", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "PackageId" });
            DropIndex("dbo.Calendars", new[] { "PackageId" });
            DropTable("dbo.Infoes");
            DropTable("dbo.Events");
            DropTable("dbo.Cupons");
            DropTable("dbo.News");
            DropTable("dbo.Galleries");
            DropTable("dbo.Users");
            DropTable("dbo.Trainers");
            DropTable("dbo.Rooms");
            DropTable("dbo.Schedules");
            DropTable("dbo.Courses");
            DropTable("dbo.Packages");
            DropTable("dbo.Calendars");
        }
    }
}

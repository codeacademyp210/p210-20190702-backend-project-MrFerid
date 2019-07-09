namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ScheduleId", "dbo.Schedules");
            DropIndex("dbo.Users", new[] { "ScheduleId" });
            AddColumn("dbo.Users", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "CourseId");
            AddForeignKey("dbo.Users", "CourseId", "dbo.Courses", "id", cascadeDelete: true);
            DropColumn("dbo.Users", "ScheduleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ScheduleId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "CourseId", "dbo.Courses");
            DropIndex("dbo.Users", new[] { "CourseId" });
            DropColumn("dbo.Users", "CourseId");
            CreateIndex("dbo.Users", "ScheduleId");
            AddForeignKey("dbo.Users", "ScheduleId", "dbo.Schedules", "id", cascadeDelete: true);
        }
    }
}

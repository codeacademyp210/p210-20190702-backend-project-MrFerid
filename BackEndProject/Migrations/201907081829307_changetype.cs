namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "StartDate", c => c.String());
            AlterColumn("dbo.Schedules", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Schedules", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}

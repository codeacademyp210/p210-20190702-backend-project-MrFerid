namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedateToStringEvent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "StartDate", c => c.String());
            AlterColumn("dbo.Events", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}

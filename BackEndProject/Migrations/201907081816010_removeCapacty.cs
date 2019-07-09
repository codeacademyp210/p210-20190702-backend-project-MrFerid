namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCapacty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Schedules", "Capacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Capacity", c => c.String(nullable: false));
        }
    }
}

namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPackages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Packages", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Packages", "CourseId", c => c.Int(nullable: false));
        }
    }
}

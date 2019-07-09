namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePackageClm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Packages", "Name", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Packages", "Name", c => c.String(maxLength: 60));
        }
    }
}

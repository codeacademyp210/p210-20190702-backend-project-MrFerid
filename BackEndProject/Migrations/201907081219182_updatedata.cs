namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Description", c => c.String(nullable: false));
        }
    }
}

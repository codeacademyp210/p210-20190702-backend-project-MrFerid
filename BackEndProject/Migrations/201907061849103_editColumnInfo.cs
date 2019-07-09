namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editColumnInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Infoes", "Username", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Infoes", "Username");
        }
    }
}

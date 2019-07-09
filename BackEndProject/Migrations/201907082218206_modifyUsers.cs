namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Payment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Payment");
        }
    }
}

namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "Pincode", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "Pincode");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "RegisterDate");
        }
    }
}

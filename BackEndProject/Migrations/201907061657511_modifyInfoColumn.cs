namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyInfoColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Infoes", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Infoes", "Photo");
        }
    }
}

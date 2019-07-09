namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCodetoCupon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cupons", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cupons", "Code");
        }
    }
}

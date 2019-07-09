namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cupons", "startDate", c => c.String());
            AlterColumn("dbo.Cupons", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cupons", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cupons", "startDate", c => c.DateTime(nullable: false));
        }
    }
}

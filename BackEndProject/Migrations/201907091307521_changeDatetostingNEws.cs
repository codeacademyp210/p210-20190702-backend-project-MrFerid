namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatetostingNEws : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}

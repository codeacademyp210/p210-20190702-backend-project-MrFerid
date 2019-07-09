namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSysUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        Status = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SystemUsers");
        }
    }
}

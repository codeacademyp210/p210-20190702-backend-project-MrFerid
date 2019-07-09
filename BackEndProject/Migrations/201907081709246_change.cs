namespace BackEndProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "PackageId", "dbo.Packages");
            DropIndex("dbo.Courses", new[] { "PackageId" });
            RenameColumn(table: "dbo.Courses", name: "PackageId", newName: "Package_id");
            AlterColumn("dbo.Courses", "Package_id", c => c.Int());
            CreateIndex("dbo.Courses", "Package_id");
            AddForeignKey("dbo.Courses", "Package_id", "dbo.Packages", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Package_id", "dbo.Packages");
            DropIndex("dbo.Courses", new[] { "Package_id" });
            AlterColumn("dbo.Courses", "Package_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Courses", name: "Package_id", newName: "PackageId");
            CreateIndex("dbo.Courses", "PackageId");
            AddForeignKey("dbo.Courses", "PackageId", "dbo.Packages", "id", cascadeDelete: true);
        }
    }
}

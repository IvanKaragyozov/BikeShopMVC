namespace BikeShopCourseWorkFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Addons_Id", "dbo.Addons");
            DropIndex("dbo.Orders", new[] { "Addons_Id" });
            RenameColumn(table: "dbo.Orders", name: "Addons_Id", newName: "AddonsId");
            AddColumn("dbo.Orders", "BikeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "AddonsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "AddonsId");
            AddForeignKey("dbo.Orders", "AddonsId", "dbo.Addons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AddonsId", "dbo.Addons");
            DropIndex("dbo.Orders", new[] { "AddonsId" });
            AlterColumn("dbo.Orders", "AddonsId", c => c.Int());
            DropColumn("dbo.Orders", "BikeId");
            RenameColumn(table: "dbo.Orders", name: "AddonsId", newName: "Addons_Id");
            CreateIndex("dbo.Orders", "Addons_Id");
            AddForeignKey("dbo.Orders", "Addons_Id", "dbo.Addons", "Id");
        }
    }
}

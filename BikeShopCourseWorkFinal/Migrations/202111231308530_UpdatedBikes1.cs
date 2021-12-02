
namespace BikeShopCourseWorkFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBikes1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bikes", "Sizes_Id", "dbo.Sizes");
            DropIndex("dbo.Bikes", new[] { "Sizes_Id" });
            RenameColumn(table: "dbo.Bikes", name: "Sizes_Id", newName: "SizesId");
            AlterColumn("dbo.Bikes", "SizesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bikes", "SizesId");
            AddForeignKey("dbo.Bikes", "SizesId", "dbo.Sizes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "SizesId", "dbo.Sizes");
            DropIndex("dbo.Bikes", new[] { "SizesId" });
            AlterColumn("dbo.Bikes", "SizesId", c => c.Int());
            RenameColumn(table: "dbo.Bikes", name: "SizesId", newName: "Sizes_Id");
            CreateIndex("dbo.Bikes", "Sizes_Id");
            AddForeignKey("dbo.Bikes", "Sizes_Id", "dbo.Sizes", "Id");
        }
    }
}

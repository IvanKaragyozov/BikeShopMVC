namespace BikeShopCourseWorkFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        AddonName = c.String(),
                        Weight = c.Double(nullable: false),
                        isToolKitIncluded = c.Boolean(nullable: false),
                        Warranty = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        TimeOfPurchase = c.DateTime(nullable: false),
                        isForCommercialUse = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        Addons_Id = c.Int(),
                        Bikes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addons", t => t.Addons_Id)
                .ForeignKey("dbo.Bikes", t => t.Bikes_Id)
                .Index(t => t.Addons_Id)
                .Index(t => t.Bikes_Id);
            
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BikeName = c.String(),
                        IsCarbon = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                        Size = c.String(),
                        Weight = c.Double(nullable: false),
                        Warranty = c.Int(nullable: true),
                        Sizes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sizes", t => t.Sizes_Id)
                .Index(t => t.Sizes_Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bikes", "Sizes_Id", "dbo.Sizes");
            DropForeignKey("dbo.Orders", "Bikes_Id", "dbo.Bikes");
            DropForeignKey("dbo.Orders", "Addons_Id", "dbo.Addons");
            DropIndex("dbo.Bikes", new[] { "Sizes_Id" });
            DropIndex("dbo.Orders", new[] { "Bikes_Id" });
            DropIndex("dbo.Orders", new[] { "Addons_Id" });
            DropTable("dbo.Sizes");
            DropTable("dbo.Bikes");
            DropTable("dbo.Orders");
            DropTable("dbo.Addons");
        }
    }
}

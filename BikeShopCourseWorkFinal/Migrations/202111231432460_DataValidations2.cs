namespace BikeShopCourseWorkFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataValidations2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addons", "AddonName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Orders", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Orders", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String(maxLength: 15));
            AlterColumn("dbo.Bikes", "BikeName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Bikes", "Size", c => c.String(maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "Size", c => c.String());
            AlterColumn("dbo.Bikes", "BikeName", c => c.String());
            AlterColumn("dbo.Orders", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Orders", "LastName", c => c.String());
            AlterColumn("dbo.Orders", "FirstName", c => c.String());
            AlterColumn("dbo.Addons", "AddonName", c => c.String(nullable: false));
        }
    }
}

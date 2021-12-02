namespace BikeShopCourseWorkFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataValidation1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addons", "AddonName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addons", "AddonName", c => c.String());
        }
    }
}

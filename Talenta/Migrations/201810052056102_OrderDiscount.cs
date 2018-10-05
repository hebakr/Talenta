namespace Talenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseOrders", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseOrders", "Discount");
        }
    }
}

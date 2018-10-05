namespace Talenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LineItemUnitPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LineItems", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LineItems", "UnitPrice");
        }
    }
}

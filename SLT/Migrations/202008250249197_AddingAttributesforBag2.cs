namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAttributesforBag2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bag", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.BagsColors", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BagsColors", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Bag", "Quantity");
        }
    }
}

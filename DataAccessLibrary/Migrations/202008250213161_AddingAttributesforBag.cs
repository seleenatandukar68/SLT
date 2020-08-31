namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAttributesforBag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BagsColors", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BagsColors", "Quantity");
        }
    }
}

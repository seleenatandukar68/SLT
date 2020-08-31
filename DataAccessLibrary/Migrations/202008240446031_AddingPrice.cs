namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bag", "sellCost", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bag", "sellCost");
        }
    }
}

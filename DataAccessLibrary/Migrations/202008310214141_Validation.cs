namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bag", "SelectedCountryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bag", "SelectedCountryId");
        }
    }
}

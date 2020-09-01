namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Picture", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Picture", "Order");
        }
    }
}

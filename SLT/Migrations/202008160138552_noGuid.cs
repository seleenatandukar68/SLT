namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Picture", "FileName", c => c.String(nullable: false));
            AddColumn("dbo.Picture", "Extension", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Picture", "Extension");
            DropColumn("dbo.Picture", "FileName");
        }
    }
}

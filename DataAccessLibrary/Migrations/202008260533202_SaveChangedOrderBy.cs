namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaveChangedOrderBy : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Picture", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Picture", "FileName", c => c.String(nullable: false));
        }
    }
}

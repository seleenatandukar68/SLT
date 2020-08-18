namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PicUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Picture", "FileContent", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Picture", "FileContent");
        }
    }
}

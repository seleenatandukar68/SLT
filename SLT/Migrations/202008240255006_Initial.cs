namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        PicId = c.Int(nullable: false, identity: true),
                        BagId = c.Int(nullable: false),
                        FileName = c.String(nullable: false),
                        Extension = c.String(),
                        FileContent = c.Binary(),
                    })
                .PrimaryKey(t => t.PicId)
                .ForeignKey("dbo.Bag", t => t.BagId, cascadeDelete: true)
                .Index(t => t.BagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Picture", "BagId", "dbo.Bag");
            DropIndex("dbo.Picture", new[] { "BagId" });
            DropTable("dbo.Picture");
        }
    }
}

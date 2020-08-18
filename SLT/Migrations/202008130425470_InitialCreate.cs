namespace SLT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bag",
                c => new
                    {
                        BagId = c.Int(nullable: false, identity: true),
                        BagBrand = c.String(nullable: false),
                        Cost = c.Single(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BagId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.BagsColors",
                c => new
                    {
                        BagId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BagId, t.ColorId })
                .ForeignKey("dbo.Bag", t => t.BagId, cascadeDelete: true)
                .ForeignKey("dbo.Color", t => t.ColorId, cascadeDelete: true)
                .Index(t => t.BagId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bag", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.BagsColors", "ColorId", "dbo.Color");
            DropForeignKey("dbo.BagsColors", "BagId", "dbo.Bag");
            DropIndex("dbo.BagsColors", new[] { "ColorId" });
            DropIndex("dbo.BagsColors", new[] { "BagId" });
            DropIndex("dbo.Bag", new[] { "CategoryId" });
            DropTable("dbo.Category");
            DropTable("dbo.Color");
            DropTable("dbo.BagsColors");
            DropTable("dbo.Bag");
        }
    }
}

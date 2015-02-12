namespace PriceComparisonTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductSKUadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSKU",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SKU = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSKU", "StoreID", "dbo.Store");
            DropForeignKey("dbo.ProductSKU", "ProductID", "dbo.Product");
            DropIndex("dbo.ProductSKU", new[] { "StoreID" });
            DropIndex("dbo.ProductSKU", new[] { "ProductID" });
            DropTable("dbo.ProductSKU");
        }
    }
}

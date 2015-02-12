namespace PriceComparisonTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            //Down();
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Price",
                c => new
                    {
                        PriceID = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PriceID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UPC = c.String(),
                        CategoryID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Units = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Price", "StoreID", "dbo.Store");
            DropForeignKey("dbo.Price", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Category", "Product_ID", "dbo.Product");
            DropIndex("dbo.Price", new[] { "StoreID" });
            DropIndex("dbo.Price", new[] { "ProductID" });
            DropIndex("dbo.Category", new[] { "Product_ID" });
            DropTable("dbo.Store");
            DropTable("dbo.Product");
            DropTable("dbo.Price");
            DropTable("dbo.Category");
        }
    }
}

namespace PriceComparisonTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListItem",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ListID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingList", t => t.ListID, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.ListID)
                .Index(t => t.ProductID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.ShoppingList",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        DateCreated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Store", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListItem", "StoreID", "dbo.Store");
            DropForeignKey("dbo.ListItem", "ListID", "dbo.ShoppingList");
            DropForeignKey("dbo.ListItem", "ProductID", "dbo.Product");
            DropIndex("dbo.ListItem", new[] { "StoreID" });
            DropIndex("dbo.ListItem", new[] { "ProductID" });
            DropIndex("dbo.ListItem", new[] { "ListID" });
            AlterColumn("dbo.Store", "Name", c => c.String(maxLength: 50));
            DropTable("dbo.ShoppingList");
            DropTable("dbo.ListItem");
        }
    }
}

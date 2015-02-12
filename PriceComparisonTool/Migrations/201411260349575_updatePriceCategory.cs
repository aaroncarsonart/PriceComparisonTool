namespace PriceComparisonTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePriceCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Product_ID", "dbo.Product");
            DropIndex("dbo.Category", new[] { "Product_ID" });
            CreateIndex("dbo.Product", "CategoryID");
            AddForeignKey("dbo.Product", "CategoryID", "dbo.Category", "ID", cascadeDelete: true);
            DropColumn("dbo.Category", "Product_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Product_ID", c => c.Int());
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryID" });
            CreateIndex("dbo.Category", "Product_ID");
            AddForeignKey("dbo.Category", "Product_ID", "dbo.Product", "ID");
        }
    }
}

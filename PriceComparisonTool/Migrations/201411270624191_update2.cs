namespace PriceComparisonTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingList", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingList", "DateCreated", c => c.Int(nullable: false));
        }
    }
}

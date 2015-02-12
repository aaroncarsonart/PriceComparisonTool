namespace PriceComparisonTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductBools : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "IsGMO", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsCO", c => c.Boolean(nullable: false));
            AddColumn("dbo.Product", "IsLG", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "IsLG");
            DropColumn("dbo.Product", "IsCO");
            DropColumn("dbo.Product", "IsGMO");
        }
    }
}

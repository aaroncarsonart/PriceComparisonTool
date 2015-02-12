namespace PriceComparisonTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListPriority : DbMigration
    {
        public override void Up()
        {
        //    CreateTable(
        //        "dbo.ListPriority",
        //        c => new
        //            {
        //                ListPriorityID = c.Int(nullable: false, identity: true),
        //                Label = c.String(),
        //            })
        //        .PrimaryKey(t => t.ListPriorityID);
            
        //    AddColumn("dbo.ShoppingList", "ListPriorityID", c => c.Int(nullable: false));
        //    CreateIndex("dbo.ShoppingList", "ListPriorityID");
        //    AddForeignKey("dbo.ShoppingList", "ListPriorityID", "dbo.ListPriority", "ListPriorityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.ShoppingList", "ListPriorityID", "dbo.ListPriority");
            //DropIndex("dbo.ShoppingList", new[] { "ListPriorityID" });
            //DropColumn("dbo.ShoppingList", "ListPriorityID");
            //DropTable("dbo.ListPriority");
        }
    }
}

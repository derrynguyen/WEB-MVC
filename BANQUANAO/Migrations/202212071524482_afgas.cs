namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afgas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListProductBills", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.ListProductBills", "Order_OrderID");
            AddForeignKey("dbo.ListProductBills", "Order_OrderID", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListProductBills", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.ListProductBills", new[] { "Order_OrderID" });
            DropColumn("dbo.ListProductBills", "Order_OrderID");
        }
    }
}

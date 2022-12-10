namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdas1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListProductBills", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.ListProductBills", new[] { "Order_OrderID" });
            AddColumn("dbo.Orders", "idHoaDon", c => c.String());
            DropColumn("dbo.ListProductBills", "Order_OrderID");
            DropColumn("dbo.Orders", "idBill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "idBill", c => c.String());
            AddColumn("dbo.ListProductBills", "Order_OrderID", c => c.Int());
            DropColumn("dbo.Orders", "idHoaDon");
            CreateIndex("dbo.ListProductBills", "Order_OrderID");
            AddForeignKey("dbo.ListProductBills", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}

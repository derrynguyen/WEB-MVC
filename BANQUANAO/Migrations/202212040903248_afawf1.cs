namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afawf1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "idHoaDon", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ListProductBill_idBill", c => c.Int());
            CreateIndex("dbo.Orders", "ListProductBill_idBill");
            AddForeignKey("dbo.Orders", "ListProductBill_idBill", "dbo.ListProductBills", "idBill");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ListProductBill_idBill", "dbo.ListProductBills");
            DropIndex("dbo.Orders", new[] { "ListProductBill_idBill" });
            DropColumn("dbo.Orders", "ListProductBill_idBill");
            DropColumn("dbo.Orders", "idHoaDon");
        }
    }
}

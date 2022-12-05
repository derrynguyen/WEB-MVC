namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awf3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ListProductBills", "Users_ID", "dbo.Users");
            DropForeignKey("dbo.Orders", "Users_ID", "dbo.Users");
            DropIndex("dbo.ListProductBills", new[] { "Users_ID" });
            DropIndex("dbo.Orders", new[] { "Users_ID" });
            RenameColumn(table: "dbo.ListProductBills", name: "Users_ID", newName: "ID");
            RenameColumn(table: "dbo.Orders", name: "Users_ID", newName: "ID");
            AlterColumn("dbo.ListProductBills", "ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "ID", c => c.Int(nullable: false));
            CreateIndex("dbo.ListProductBills", "ID");
            CreateIndex("dbo.Orders", "ID");
            AddForeignKey("dbo.ListProductBills", "ID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ID", "dbo.Users", "ID", cascadeDelete: true);
            DropColumn("dbo.ListProductBills", "IDUser");
            DropColumn("dbo.Orders", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.ListProductBills", "IDUser", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "ID", "dbo.Users");
            DropForeignKey("dbo.ListProductBills", "ID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "ID" });
            DropIndex("dbo.ListProductBills", new[] { "ID" });
            AlterColumn("dbo.Orders", "ID", c => c.Int());
            AlterColumn("dbo.ListProductBills", "ID", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "ID", newName: "Users_ID");
            RenameColumn(table: "dbo.ListProductBills", name: "ID", newName: "Users_ID");
            CreateIndex("dbo.Orders", "Users_ID");
            CreateIndex("dbo.ListProductBills", "Users_ID");
            AddForeignKey("dbo.Orders", "Users_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.ListProductBills", "Users_ID", "dbo.Users", "ID");
        }
    }
}

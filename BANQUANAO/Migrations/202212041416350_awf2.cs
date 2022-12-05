namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awf2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListProductBills", "Users_ID", c => c.Int());
            CreateIndex("dbo.ListProductBills", "Users_ID");
            AddForeignKey("dbo.ListProductBills", "Users_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListProductBills", "Users_ID", "dbo.Users");
            DropIndex("dbo.ListProductBills", new[] { "Users_ID" });
            DropColumn("dbo.ListProductBills", "Users_ID");
        }
    }
}

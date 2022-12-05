namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awf1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Users_ID", c => c.Int());
            CreateIndex("dbo.Orders", "Users_ID");
            AddForeignKey("dbo.Orders", "Users_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Users_ID", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "Users_ID" });
            DropColumn("dbo.Orders", "Users_ID");
        }
    }
}

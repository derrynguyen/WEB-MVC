namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awf4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "ID", c => c.Int(nullable: false));
            CreateIndex("dbo.CartItems", "ID");
            AddForeignKey("dbo.CartItems", "ID", "dbo.Users", "ID", cascadeDelete: true);
            DropColumn("dbo.CartItems", "IDUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "IDUser", c => c.Int(nullable: false));
            DropForeignKey("dbo.CartItems", "ID", "dbo.Users");
            DropIndex("dbo.CartItems", new[] { "ID" });
            DropColumn("dbo.CartItems", "ID");
        }
    }
}

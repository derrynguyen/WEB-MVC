namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awfawfawfawfawfafaf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "phoneNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "phoneNumber");
        }
    }
}

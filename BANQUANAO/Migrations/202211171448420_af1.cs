namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class af1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ListProductBills", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListProductBills", "TotalPrice", c => c.Int(nullable: false));
        }
    }
}

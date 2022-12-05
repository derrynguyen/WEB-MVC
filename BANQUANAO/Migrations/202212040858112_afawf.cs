namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afawf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListProductBills", "idHoaDon", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListProductBills", "idHoaDon");
        }
    }
}

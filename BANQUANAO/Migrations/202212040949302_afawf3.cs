namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afawf3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ListProductBills", "idHoaDon", c => c.String());
            AlterColumn("dbo.Orders", "idHoaDon", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "idHoaDon", c => c.Int(nullable: false));
            AlterColumn("dbo.ListProductBills", "idHoaDon", c => c.Int(nullable: false));
        }
    }
}

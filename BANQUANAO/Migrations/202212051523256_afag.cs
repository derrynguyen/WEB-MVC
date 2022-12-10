namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListProductBills", "idHoaDon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListProductBills", "idHoaDon");
        }
    }
}

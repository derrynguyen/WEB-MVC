namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class awf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ListProductBills", "idHoaDon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ListProductBills", "idHoaDon", c => c.String());
        }
    }
}

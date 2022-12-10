namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "idBill", c => c.String());
            DropColumn("dbo.Orders", "idHoaDon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "idHoaDon", c => c.String());
            DropColumn("dbo.Orders", "idBill");
        }
    }
}

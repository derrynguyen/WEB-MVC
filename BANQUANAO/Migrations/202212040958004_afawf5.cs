namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afawf5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartItems", "idHoaDon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartItems", "idHoaDon", c => c.String());
        }
    }
}

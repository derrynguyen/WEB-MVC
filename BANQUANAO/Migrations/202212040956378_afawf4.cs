namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afawf4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "idHoaDon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "idHoaDon");
        }
    }
}

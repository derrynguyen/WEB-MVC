namespace BANQUANAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class af : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListProductBills",
                c => new
                    {
                        idBill = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        productID = c.Int(nullable: false),
                        nameProduct = c.String(),
                        IDUser = c.Int(nullable: false),
                        priceProduct = c.Int(nullable: false),
                        sizeProduct = c.String(),
                        colorProduct = c.String(),
                        Amount = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idBill);
            
          
        }
        
        public override void Down()
        {
           
            
            DropTable("dbo.ListProductBills");
        }
    }
}

namespace ProiectII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStockModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Products", "Code", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Code", unique: true);
            DropColumn("dbo.Products", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Stock", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stocks", "Product_Id", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Code" });
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Products", "Code");
            DropTable("dbo.Stocks");
        }
    }
}

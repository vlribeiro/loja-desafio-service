namespace LojaDesafio.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionProductsMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionProducts", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.TransactionProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.TransactionProducts", new[] { "Transaction_Id" });
            DropIndex("dbo.TransactionProducts", new[] { "Product_Id" });
            DropTable("dbo.TransactionProducts");
            CreateTable(
                "dbo.TransactionProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.TransactionId)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Transactions", "Product_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "Product_Id");
            AddForeignKey("dbo.Transactions", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Transactions", "Value");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TransactionProducts",
                c => new
                    {
                        Transaction_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transaction_Id, t.Product_Id });
            
            AddColumn("dbo.Transactions", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Transactions", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.TransactionProducts", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.TransactionProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.TransactionProducts", new[] { "ProductId" });
            DropIndex("dbo.TransactionProducts", new[] { "TransactionId" });
            DropIndex("dbo.Transactions", new[] { "Product_Id" });
            DropColumn("dbo.Transactions", "Product_Id");
            DropTable("dbo.TransactionProducts");
            CreateIndex("dbo.TransactionProducts", "Product_Id");
            CreateIndex("dbo.TransactionProducts", "Transaction_Id");
            AddForeignKey("dbo.TransactionProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TransactionProducts", "Transaction_Id", "dbo.Transactions", "Id", cascadeDelete: true);
        }
    }
}

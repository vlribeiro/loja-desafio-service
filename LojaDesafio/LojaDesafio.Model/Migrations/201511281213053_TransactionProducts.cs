namespace LojaDesafio.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionProducts",
                c => new
                    {
                        Transaction_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transaction_Id, t.Product_Id })
                .ForeignKey("dbo.Transactions", t => t.Transaction_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Transaction_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.TransactionProducts", "Transaction_Id", "dbo.Transactions");
            DropIndex("dbo.TransactionProducts", new[] { "Product_Id" });
            DropIndex("dbo.TransactionProducts", new[] { "Transaction_Id" });
            DropTable("dbo.TransactionProducts");
        }
    }
}

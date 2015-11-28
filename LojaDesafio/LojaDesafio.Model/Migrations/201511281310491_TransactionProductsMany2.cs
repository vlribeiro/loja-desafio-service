namespace LojaDesafio.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionProductsMany2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Product_Id", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "Product_Id" });
            DropColumn("dbo.Transactions", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Product_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "Product_Id");
            AddForeignKey("dbo.Transactions", "Product_Id", "dbo.Products", "Id");
        }
    }
}

namespace LojaDesafio.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cardholder = c.String(),
                        Number = c.String(),
                        ExpirationMonth = c.Int(nullable: false),
                        ExpirationYear = c.Int(nullable: false),
                        CardIssuer = c.Int(nullable: false),
                        CSC = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreditCardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CreditCards", t => t.CreditCardId, cascadeDelete: true)
                .Index(t => t.CreditCardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CreditCardId", "dbo.CreditCards");
            DropIndex("dbo.Transactions", new[] { "CreditCardId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Products");
            DropTable("dbo.CreditCards");
        }
    }
}

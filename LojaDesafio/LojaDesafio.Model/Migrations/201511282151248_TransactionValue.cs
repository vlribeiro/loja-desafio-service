namespace LojaDesafio.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Value");
        }
    }
}

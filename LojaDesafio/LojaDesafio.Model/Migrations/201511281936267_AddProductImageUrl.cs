namespace LojaDesafio.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}

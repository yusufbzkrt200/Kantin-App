namespace Kantin.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faturas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Toplam = c.Single(nullable: false),
                        Urunler = c.String(),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        FaturaLink = c.String(),
                        Cash = c.Boolean(nullable: false),
                        Iade = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Single(nullable: false),
                        Barcode = c.String(),
                        Stock = c.Int(nullable: false),
                        UrunLink = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Faturas");
            DropTable("dbo.Categories");
        }
    }
}

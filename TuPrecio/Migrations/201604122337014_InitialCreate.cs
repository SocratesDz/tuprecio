namespace TuPrecio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsertDate = c.DateTime(nullable: false),
                        Currency_Id = c.Int(),
                        Location_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currencies", t => t.Currency_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.UnitTypes", t => t.Type_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Symbol = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnitTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Type_Id", "dbo.UnitTypes");
            DropForeignKey("dbo.Articles", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Articles", "Currency_Id", "dbo.Currencies");
            DropIndex("dbo.Articles", new[] { "Type_Id" });
            DropIndex("dbo.Articles", new[] { "Location_Id" });
            DropIndex("dbo.Articles", new[] { "Currency_Id" });
            DropTable("dbo.UnitTypes");
            DropTable("dbo.Locations");
            DropTable("dbo.Currencies");
            DropTable("dbo.Articles");
        }
    }
}

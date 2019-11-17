namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CitiesUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Population = c.Int(nullable: false),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cinemas", "CityId", "dbo.Cities");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Cinemas", new[] { "CityId" });
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Cinemas");
        }
    }
}

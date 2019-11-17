namespace lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountriesUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Countries", "Area", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Countries", "WasFounded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Countries", "WasFounded");
            DropColumn("dbo.Countries", "Area");
        }
    }
}

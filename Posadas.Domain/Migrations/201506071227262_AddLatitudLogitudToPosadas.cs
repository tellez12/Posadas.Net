namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLatitudLogitudToPosadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posadas", "Latitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Posadas", "Longitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posadas", "Longitud");
            DropColumn("dbo.Posadas", "Latitud");
        }
    }
}

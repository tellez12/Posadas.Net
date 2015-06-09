namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uknown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posadas", "Latitud", c => c.Decimal(nullable: false, precision: 18, scale: 9));
            AlterColumn("dbo.Posadas", "Longitud", c => c.Decimal(nullable: false, precision: 18, scale: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posadas", "Longitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Posadas", "Latitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

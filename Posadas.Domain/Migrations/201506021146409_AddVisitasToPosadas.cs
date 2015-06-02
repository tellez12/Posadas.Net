namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitasToPosadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posadas", "Visitas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posadas", "Visitas");
        }
    }
}

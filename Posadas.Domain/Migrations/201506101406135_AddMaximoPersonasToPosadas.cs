namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaximoPersonasToPosadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HabitacionesPosadas", "MaximoPersonas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HabitacionesPosadas", "MaximoPersonas");
        }
    }
}

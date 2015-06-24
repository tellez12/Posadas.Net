namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHabitacionesCompartidas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HabitacionesPosadas", "HabitacionCompartida", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HabitacionesPosadas", "HabitacionCompartida");
        }
    }
}

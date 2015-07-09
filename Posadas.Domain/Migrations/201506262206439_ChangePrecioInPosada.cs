namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePrecioInPosada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HabitacionesPosadas", "PrecioHabitacionMin", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HabitacionesPosadas", "PrecioHabitacionMax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.HabitacionesPosadas", "PrecioHabitacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HabitacionesPosadas", "PrecioHabitacion", c => c.String());
            DropColumn("dbo.HabitacionesPosadas", "PrecioHabitacionMax");
            DropColumn("dbo.HabitacionesPosadas", "PrecioHabitacionMin");
        }
    }
}

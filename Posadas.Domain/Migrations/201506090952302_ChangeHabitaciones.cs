namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeHabitaciones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HabitacionesPosadas", "TipoHabitacionId", "dbo.TipoHabitacions");
            DropIndex("dbo.HabitacionesPosadas", new[] { "TipoHabitacionId" });
            AddColumn("dbo.HabitacionesPosadas", "TipoHabitacion", c => c.String());
            AddColumn("dbo.HabitacionesPosadas", "PrecioHabitacion", c => c.String());
            DropColumn("dbo.HabitacionesPosadas", "TipoHabitacionId");
            DropTable("dbo.TipoHabitacions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TipoHabitacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CantidadHuespedes = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.HabitacionesPosadas", "TipoHabitacionId", c => c.Int(nullable: false));
            DropColumn("dbo.HabitacionesPosadas", "PrecioHabitacion");
            DropColumn("dbo.HabitacionesPosadas", "TipoHabitacion");
            CreateIndex("dbo.HabitacionesPosadas", "TipoHabitacionId");
            AddForeignKey("dbo.HabitacionesPosadas", "TipoHabitacionId", "dbo.TipoHabitacions", "Id", cascadeDelete: true);
        }
    }
}

namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caracteristicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TipoCaracteristicaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCaracteristicas", t => t.TipoCaracteristicaId, cascadeDelete: true)
                .Index(t => t.TipoCaracteristicaId);
            
            CreateTable(
                "dbo.TipoCaracteristicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Orden = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CaracteristicasPosadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CaracteristicaId = c.Int(nullable: false),
                        PosadaId = c.Int(nullable: false),
                        Valor = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Caracteristicas", t => t.CaracteristicaId, cascadeDelete: true)
                .ForeignKey("dbo.Posadas", t => t.PosadaId, cascadeDelete: true)
                .Index(t => t.CaracteristicaId)
                .Index(t => t.PosadaId);
            
            CreateTable(
                "dbo.Posadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Email = c.String(),
                        Contacto = c.String(),
                        Aprovado = c.Boolean(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HabitacionesPosadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipoHabitacionId = c.Int(nullable: false),
                        PosadaId = c.Int(nullable: false),
                        CantidadHabitaciones = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posadas", t => t.PosadaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoHabitacions", t => t.TipoHabitacionId, cascadeDelete: true)
                .Index(t => t.TipoHabitacionId)
                .Index(t => t.PosadaId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HabitacionesPosadas", "TipoHabitacionId", "dbo.TipoHabitacions");
            DropForeignKey("dbo.HabitacionesPosadas", "PosadaId", "dbo.Posadas");
            DropForeignKey("dbo.CaracteristicasPosadas", "PosadaId", "dbo.Posadas");
            DropForeignKey("dbo.CaracteristicasPosadas", "CaracteristicaId", "dbo.Caracteristicas");
            DropForeignKey("dbo.Caracteristicas", "TipoCaracteristicaId", "dbo.TipoCaracteristicas");
            DropIndex("dbo.HabitacionesPosadas", new[] { "PosadaId" });
            DropIndex("dbo.HabitacionesPosadas", new[] { "TipoHabitacionId" });
            DropIndex("dbo.CaracteristicasPosadas", new[] { "PosadaId" });
            DropIndex("dbo.CaracteristicasPosadas", new[] { "CaracteristicaId" });
            DropIndex("dbo.Caracteristicas", new[] { "TipoCaracteristicaId" });
            DropTable("dbo.TipoHabitacions");
            DropTable("dbo.HabitacionesPosadas");
            DropTable("dbo.Posadas");
            DropTable("dbo.CaracteristicasPosadas");
            DropTable("dbo.TipoCaracteristicas");
            DropTable("dbo.Caracteristicas");
        }
    }
}

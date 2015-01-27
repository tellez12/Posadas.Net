namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FotosPosadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ruta = c.String(),
                        Alt = c.String(),
                        PosadaId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posadas", t => t.PosadaId, cascadeDelete: true)
                .Index(t => t.PosadaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FotosPosadas", "PosadaId", "dbo.Posadas");
            DropIndex("dbo.FotosPosadas", new[] { "PosadaId" });
            DropTable("dbo.FotosPosadas");
        }
    }
}

namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLugarAndPosadaMisc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lugares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        EstadoId = c.Int(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estados", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            AddColumn("dbo.Posadas", "WebSite", c => c.String());
            AddColumn("dbo.Posadas", "Twitter", c => c.String());
            AddColumn("dbo.Posadas", "LugarId", c => c.Int());
            AddColumn("dbo.Posadas", "Misc", c => c.String(maxLength: 1000));
            CreateIndex("dbo.Posadas", "LugarId");
            AddForeignKey("dbo.Posadas", "LugarId", "dbo.Lugares", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posadas", "LugarId", "dbo.Lugares");
            DropForeignKey("dbo.Lugares", "EstadoId", "dbo.Estados");
            DropIndex("dbo.Lugares", new[] { "EstadoId" });
            DropIndex("dbo.Posadas", new[] { "LugarId" });
            DropColumn("dbo.Posadas", "Misc");
            DropColumn("dbo.Posadas", "LugarId");
            DropColumn("dbo.Posadas", "Twitter");
            DropColumn("dbo.Posadas", "WebSite");
            DropTable("dbo.Lugares");
        }
    }
}

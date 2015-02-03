namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableStado : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posadas", "EstadoId", "dbo.Estados");
            DropIndex("dbo.Posadas", new[] { "EstadoId" });
            AlterColumn("dbo.Posadas", "EstadoId", c => c.Int());
            CreateIndex("dbo.Posadas", "EstadoId");
            AddForeignKey("dbo.Posadas", "EstadoId", "dbo.Estados", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posadas", "EstadoId", "dbo.Estados");
            DropIndex("dbo.Posadas", new[] { "EstadoId" });
            AlterColumn("dbo.Posadas", "EstadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posadas", "EstadoId");
            AddForeignKey("dbo.Posadas", "EstadoId", "dbo.Estados", "Id", cascadeDelete: true);
        }
    }
}

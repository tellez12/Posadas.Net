namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEstadoId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posadas", "Estado_Id", "dbo.Estados");
            DropIndex("dbo.Posadas", new[] { "Estado_Id" });
            RenameColumn(table: "dbo.Posadas", name: "Estado_Id", newName: "EstadoId");
            AlterColumn("dbo.Posadas", "EstadoId", c => c.Int(nullable: true));
            CreateIndex("dbo.Posadas", "EstadoId");
            AddForeignKey("dbo.Posadas", "EstadoId", "dbo.Estados", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posadas", "EstadoId", "dbo.Estados");
            DropIndex("dbo.Posadas", new[] { "EstadoId" });
            AlterColumn("dbo.Posadas", "EstadoId", c => c.Int());
            RenameColumn(table: "dbo.Posadas", name: "EstadoId", newName: "Estado_Id");
            CreateIndex("dbo.Posadas", "Estado_Id");
            AddForeignKey("dbo.Posadas", "Estado_Id", "dbo.Estados", "Id");
        }
    }
}

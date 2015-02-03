namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posadas", "Estado_Id", c => c.Int());
            CreateIndex("dbo.Posadas", "Estado_Id");
            AddForeignKey("dbo.Posadas", "Estado_Id", "dbo.Estados", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posadas", "Estado_Id", "dbo.Estadoes");
            DropIndex("dbo.Posadas", new[] { "Estado_Id" });
            DropColumn("dbo.Posadas", "Estado_Id");
            DropTable("dbo.Estados");
        }
    }
}

namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagenCaracteristica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Caracteristicas", "Imagen", c => c.String(defaultValue:"noImagen.jpg") );
        }
        
        public override void Down()
        {
            DropColumn("dbo.Caracteristicas", "Imagen");
        }
    }
}

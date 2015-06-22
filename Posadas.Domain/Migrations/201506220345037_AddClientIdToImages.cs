namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientIdToImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Caracteristicas", "ImagenPublicId", c => c.String());
            AddColumn("dbo.FotosPosadas", "ImagenPublicId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FotosPosadas", "ImagenPublicId");
            DropColumn("dbo.Caracteristicas", "ImagenPublicId");
        }
    }
}

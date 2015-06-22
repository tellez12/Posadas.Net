namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageServer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Caracteristicas", "ImageServer", c => c.Int(nullable: false));
            AddColumn("dbo.FotosPosadas", "ImageServer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FotosPosadas", "ImageServer");
            DropColumn("dbo.Caracteristicas", "ImageServer");
        }
    }
}

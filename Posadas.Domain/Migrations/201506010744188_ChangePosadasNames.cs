namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangePosadasNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Posadas", "Aprovado", "Aprobado");
            RenameColumn("dbo.Posadas", "Contacto", "Telefono");
        }

        public override void Down()
        {
            RenameColumn("dbo.Posadas", "Aprobado", "Aprovado");
            RenameColumn("dbo.Posadas", "Telefono", "Contacto");
        }
    }
}

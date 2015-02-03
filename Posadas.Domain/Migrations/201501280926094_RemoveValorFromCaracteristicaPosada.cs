namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveValorFromCaracteristicaPosada : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CaracteristicasPosadas", "Valor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CaracteristicasPosadas", "Valor", c => c.String());
        }

    }
}

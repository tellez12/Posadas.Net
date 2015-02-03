namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstado1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Estados", newName: "Estados");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Estados", newName: "Estados");
        }
    }
}

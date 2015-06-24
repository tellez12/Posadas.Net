namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFAcebookToPosadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posadas", "Facebook", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posadas", "Facebook");
        }
    }
}

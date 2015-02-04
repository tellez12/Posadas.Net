using Microsoft.AspNet.Identity.EntityFramework;
using Posadas.Domain.EF;

namespace Posadas.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
                context.Roles.Add(new IdentityRole("Admin"));
            
        }
    }
}

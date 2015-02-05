using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;

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
            string[] adminsEmails =  { "luistellez@gmail.com", "bello.fuentes@gmail.com" };
            const string adminRoleName = "Admin";

            if (!context.Roles.Any(r => r.Name == adminRoleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = adminRoleName };

                manager.Create(role);
            }

          
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
              

            foreach (var email in adminsEmails)
            {
                var user = userManager.FindByEmail(email);
                if (user != null)
                {
                    if (!userManager.IsInRole(user.Id, adminRoleName))
                    {
                        userManager.AddToRole(user.Id, adminRoleName);
                    }
                    
                }
            }
              
        }
    }
}

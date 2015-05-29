using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;

namespace Posadas.Domain.Migrations
{
    using Posadas.Domain.UOW;
    using Posadas.Utils;
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
            // Start debugger
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            string[] adminsEmails = { "luistellez@gmail.com", "bello.fuentes@gmail.com" };
            const string adminRoleName = "Admin";

            if (!context.Roles.Any(r => r.Name == adminRoleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = adminRoleName };

                manager.Create(role);
            }


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore) {EmailService = Email.MyEmailService};


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

            string[] estados = {"Anzoátegui","Apure","Aragua","Barinas","Bolívar","Carabobo","Cojedes",
                                "Delta Amacuro","Distrito Capital","Falcón","Guárico","Lara","Mérida",
                                "Miranda","Monagas","Nueva Esparta","Portuguesa","Sucre","Tachira",
                                "Trujillo","Vargas","Yaracuy","Zulia"};
            var uw = new EFUnitOfWork();
            var estadosDB =uw.EstadoRepository.Get().Select(e=>e.Nombre);
            estados=estados.Where(e=> !estadosDB.Contains(e) ).ToArray();
            uw.EstadoRepository.Insert(estados.Select(e=> new Estado(){Nombre=e} ).ToList());
            uw.Save();
           

        }
    }
}

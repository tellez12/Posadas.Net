﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Posadas.Domain.Entities;

namespace Posadas.Domain.EF
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            : base("DefaultConnection")
        {

        }

        public override int SaveChanges()
        {
            ObjectContext ctx = ((IObjectContextAdapter)this).ObjectContext;

            var inserting = ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Added).Select(e => e.Entity).
               Where(e => e.GetType().IsSubclassOf(typeof(BaseEntity))).ToList();

            var updating = ctx.ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Select(e => e.Entity).
               Where(e => e.GetType().IsSubclassOf(typeof(BaseEntity))).ToList();

            foreach (BaseEntity entity in inserting)
            {
                entity.FechaCreacion = DateTime.Now;
                entity.FechaModificacion = DateTime.Now;
            }

            foreach (BaseEntity entity in updating)
            {
                entity.FechaCreacion = DateTime.Now;
                entity.FechaModificacion = DateTime.Now;
                var entry = this.Entry(entity);
                entry.State = EntityState.Modified;
                //Exclude FechaCreacion from been modified.
                entry.Property("FechaCreacion").IsModified = false;
            }
            return base.SaveChanges();
        }



        public DbSet<Posada> Posadas { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }

        public DbSet<TipoCaracteristica> TipoCaracteristicas { get; set; }

     

        public DbSet<HabitacionesPosada> HabitacionesPosadas { get; set; }

        public DbSet<CaracteristicasPosadas> CaracteristicasPosadases { get; set; }

        public DbSet<FotosPosada> FotosPosadas { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Lugar> Lugares { get; set; }

        public static MyContext Create()
        {
            return new MyContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Posada>()
                .Property(a => a.Latitud).HasPrecision(18, 9);
            modelBuilder.Entity<Posada>().Property(a => a.Longitud).HasPrecision(18, 9);
            base.OnModelCreating(modelBuilder);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Posadas.Domain.EF;
using Posadas.Domain.Entities;

namespace Posadas.Domain.UOW
{
    public class PosadasRepository : GenericRepository<Posada>
    {
        public PosadasRepository(MyContext context) : base(context)
        {
            
        }

        public override void Update(Posada entityToUpdate)
        {
            foreach (var habitacion in entityToUpdate.Habitaciones)
            {
                var entry = Context.Entry(habitacion);
                entry.State = EntityState.Modified;
            }
            base.Update(entityToUpdate);
        }

    }
}

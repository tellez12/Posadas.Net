using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
    public class TipoHabitacion:BaseEntity
    {
        public int CantidadHuespedes { get; set; }

        public string Nombre { get; set; }


    }
}

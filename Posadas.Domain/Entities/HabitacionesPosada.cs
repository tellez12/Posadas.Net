using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
    public class HabitacionesPosada:BaseEntity
    {

        public string TipoHabitacion { get; set; }
        public string PrecioHabitacion { get; set; }

        public int MaximoPersonas { get; set; }
        public int PosadaId { get; set; }

        [ForeignKey("PosadaId")]
        public Posada Posada { get; set; }
        public int CantidadHabitaciones { get; set; }

    }
}

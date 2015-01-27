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

        public int TipoHabitacionId { get; set; }

        [ForeignKey("TipoHabitacionId")]
        public TipoHabitacion Tipo { get; set; }
        
        public int PosadaId { get; set; }

        [ForeignKey("PosadaId")]
        public Posada Posada { get; set; }
        public int CantidadHabitaciones { get; set; }

    }
}

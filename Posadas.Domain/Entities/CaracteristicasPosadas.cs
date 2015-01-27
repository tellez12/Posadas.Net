using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
   public class CaracteristicasPosadas:BaseEntity
    {
       public int CaracteristicaId { get; set; }

        [ForeignKey("CaracteristicaId")]
       public Caracteristica Caracteristica { get; set; }

        public int PosadaId { get; set; }

        [ForeignKey("PosadaId")]
       public Posada Posada { get; set; }

       public string Valor { get; set; }

    }
}

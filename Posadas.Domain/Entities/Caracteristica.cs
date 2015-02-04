using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
    public class Caracteristica :BaseEntity
    {
        public string Nombre { get; set; }
        public int TipoCaracteristicaId { get; set; }

        [ForeignKey("TipoCaracteristicaId")]
        public virtual TipoCaracteristica TipoCaracteristica { get; set; }

        public string Imagen { get; set; }

        
    }
}

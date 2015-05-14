using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Posadas.Domain.Entities
{
    [Table("Lugares")]
   public class Lugar:BaseEntity
    {
        public string Nombre { get; set; }
        public int? EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
    public class Posada:BaseEntity
    {
       
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public bool Aprobado { get; set; }

        public string WebSite { get; set; }

        public string Twitter  { get; set; }
        public virtual List<CaracteristicasPosadas> Caracteristicas { get; set; }

        public virtual List<HabitacionesPosada> Habitaciones { get; set; }

        public virtual List<FotosPosada> Fotos { get; set; }

        public int? EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }

        public string UserId { get; set; }

         [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

         public int? LugarId { get; set; }

         [ForeignKey("LugarId")]
         public Lugar Lugar { get; set; }

        [StringLength(1000)]
         public string Misc { get; set; }

        public int Visitas { get; set; }


    }
}



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

        public string Contacto { get; set; }

        public bool Aprovado { get; set; }

        public virtual List<CaracteristicasPosadas> Caracteristicas { get; set; }

        public virtual List<HabitacionesPosada> Habitaciones { get; set; }

        public virtual List<FotosPosada> Fotos { get; set; }

        public int? EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }


    }
}



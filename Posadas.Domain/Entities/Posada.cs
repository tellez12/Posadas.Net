using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [EmailAddress(ErrorMessage = "Direccion de Email Invalida")]
        public string Email { get; set; }

        public string Contacto { get; set; }

        public bool Aprovado { get; set; }

        public virtual List<CaracteristicasPosadas> Caracteristicas { get; set; }

        public virtual List<HabitacionesPosada> Habitaciones { get; set; }

        public virtual List<FotosPosada> Fotos { get; set; } 


    }
}



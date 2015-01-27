using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
   public class TipoCaracteristica:BaseEntity
    {
       public string Nombre { get; set; }

       public int Orden { get; set; }

    }
}

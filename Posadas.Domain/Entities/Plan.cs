using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
    public class Plan:BaseEntity
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int NumImagenes { get; set; }

    }
}

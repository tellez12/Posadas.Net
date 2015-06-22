using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{
    public class FotosPosada : BaseEntity
    {
        public string Ruta { get; set; }

        public string ImagenPublicId { get; set; }
        public string Alt { get; set; }


        public int PosadaId { get; set; }
        [ForeignKey("PosadaId")]
        public Posada Posada { get; set; }


        public int Order { get; set; }

        public int ImageServer { get; set; }


    }
}

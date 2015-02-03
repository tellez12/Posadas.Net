using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Domain.Entities
{

    [Table("Estados")]
    public class Estado : BaseEntity
    {
        public string Nombre { get; set; }
    }
}

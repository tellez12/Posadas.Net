using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Posadas.Domain.Entities;

namespace Posadas.WebUI.ViewModels.Posadas
{
    public class PosadasSearchViewModel
    {
        public string Query { get; set; }
        public int? Estado { get; set; }
        public int? Lugar { get; set; }
        public SelectList Estados { get; set; }
        public SelectList Lugares { get; set; }
        public int? PrecioMinimo { get; set; }
        public int? PrecioMaximo { get; set; }
        public int? CapacidadMinima { get; set; }
        public int? CapacidadMaxima { get; set; }
        public virtual List<Caracteristica> Caracteristicas { get; set; }

        public List<int> CaracteristicasId { get; set; }
        

    }
}
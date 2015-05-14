using Posadas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posadas.WebUI.Api.Models
{
    public class PosadasApiViewModel
    {
        public PosadasApiViewModel(){}
        public PosadasApiViewModel(Posada posada)
        {
            Nombre = posada.Nombre;
            Id = posada.Id;
            Fotos = new List<FotosApiViewModel>();
            foreach (var item in posada.Fotos)
            {
                Fotos.Add(new FotosApiViewModel(item));
            }
        }
        public string Nombre { get; set; }

        public int Id { get; set; }

        public List<FotosApiViewModel> Fotos { get; set; }
    }

    public class FotosApiViewModel
    {
        public FotosApiViewModel() { 
        }
        public FotosApiViewModel(FotosPosada foto){
            Ruta=foto.Ruta;
            Alt=foto.Alt;
        }
        public string Ruta { get; set; }

        public string Alt { get; set; }
    }
}
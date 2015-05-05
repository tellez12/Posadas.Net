using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posadas.WebUI.ViewModels.Posadas
{
    public class FotoPosadaViewModel
    {
        public HttpPostedFileBase FileBase { get; set; }

        public string Alt { get; set; }

    }
}
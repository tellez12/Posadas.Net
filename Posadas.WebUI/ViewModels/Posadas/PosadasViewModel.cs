﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Posadas.Domain.Entities;
using CloudinaryDotNet;

namespace Posadas.WebUI.ViewModels.Posadas
{
    public class PosadasViewModel
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [EmailAddress(ErrorMessage = "Direccion de Email Invalida")]
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string WebSite { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public bool Aprobado { get; set; }
        public virtual List<CaracteristicasPosadas> Caracteristicas { get; set; }
        public virtual List<HabitacionesPosada> Habitaciones { get; set; }
        public virtual List<FotosPosada> Fotos { get; set; }
        public int[] CaracteristicasId { get; set; }
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }
        public Lugar Lugar { get; set; }
        public int LugarId { get; set; }
        public SelectList Estados { get; set; }
        public SelectList Lugares { get; set; }
        public List<FotoPosadaViewModel> FotosModels { get; set; }
        public string OtroLugar { get; set; }
        public int Visitas { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }

        public CloudinaryDotNet.Cloudinary Cloudinary { get; set; }

    }
}
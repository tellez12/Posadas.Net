using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posadas.WebUI.Utils
{
    //Define all the configurations from this file, change the values latter to be read from 
    public static class Constantes
    {
        #region Imagenes
        public static string PosadaSinImagen
        {
            get { return "~/ImagenesPosadas/no-image.png"; }
        }
        public static string PosadasBase
        {
            get { return "~/ImagenesPosadas/Uploaded/"; }
        }
        public static string CaracteristicasBase
        {
            get { return "~/Caracteristicas/"; }
        }

        #endregion


        public static int NumeroDeFotos
        {
            get { return 5; }
        }
    }
}
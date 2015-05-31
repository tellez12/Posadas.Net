using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posadas.Utils
{
    class Settings
    {
        public void X()
        {
            string strVal = System.Configuration.ConfigurationManager.AppSettings["serviceUrl"];
        }
    }
}

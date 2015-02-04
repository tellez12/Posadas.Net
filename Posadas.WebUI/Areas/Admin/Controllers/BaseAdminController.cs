using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BaseAdminController : Controller
    {
     
    }
}
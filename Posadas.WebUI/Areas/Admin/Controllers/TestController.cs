using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posadas.WebUI.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Admin/Test
        public Boolean Email(string body="serviceTest")
        {
            Posadas.Utils.Email.SendMessageWithService(body);

            return true;
        }
    }
}
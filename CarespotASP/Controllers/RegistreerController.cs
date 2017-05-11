using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarespotASP.Controllers
{
    public class RegistreerController : Controller
    {
        // GET: Registreer
        public ActionResult Index()
        {
            return View("Registreer");
        }
    }
}
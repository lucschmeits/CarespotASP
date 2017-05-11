using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarespotASP.Controllers
{
    public class HulpbehoevendeController : Controller
    {
        // GET: Hulpbehoevende
        public ActionResult Index()
        {
            return View("Opdrachten");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class VrijwilligerController : Controller
    {
        // GET: Vrijwilliger
        public ActionResult Index()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            List<Hulpvraag> hulpvragen = hvr.GetHulpvragenByVrijwilligerId(4);
            ViewBag.hulpvragen = hulpvragen;

            return View("~/Views/Vrijwilliger/Hoofdscherm.cshtml");
        }

        public ActionResult OpdrachtOverzicht()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            List<Hulpvraag> hulpvragen = hvr.GetHulpvragenByVrijwilligerId(4);
            ViewBag.hulpvragen = hulpvragen;

            return View("~/Views/Vrijwilliger/OpdrachtOverzicht.cshtml");
        }

        [HttpGet]
        public ActionResult Reageer(int id)
        {
            return View("~/Views/Vrijwilliger/Reageer.cshtml");
        }


    }
}
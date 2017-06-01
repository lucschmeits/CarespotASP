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
    public class HulpbehoevendeController : Controller
    {
        // GET: Hulpbehoevende
        public ActionResult Index()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            List<Hulpvraag> hulpvragen = hvr.GetHulpvragenByHulpbehoevendeId(4);
            ViewBag.hulpvragen = hulpvragen;

            return View("~/Views/Hulpbehoevende/Opdrachten.cshtml");

        }

        [HttpGet]
        public ActionResult DeleteHulpvraag(int id)
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            hvr.Delete(id);

            return Index();
        }
    }
}
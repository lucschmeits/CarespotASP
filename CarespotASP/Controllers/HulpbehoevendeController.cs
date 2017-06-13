using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class HulpbehoevendeController : Controller
    {
        // GET: Hulpbehoevende
        public ActionResult Index()
        {
            try
            {
                var hulpbehoevende = (Hulpbehoevende) Session["LoggedInUser"];

                HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
                HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

                List<Hulpvraag> hulpvragen = hvr.GetHulpvragenByHulpbehoevendeId(hulpbehoevende.Id);
                ViewBag.hulpvragen = hulpvragen;

                return View("~/Views/Hulpbehoevende/Opdrachten.cshtml");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        public ActionResult NieuweOpdracht()
        {
            try
            {
                VaardigheidSqlContext vsc = new VaardigheidSqlContext();
                VaardigheidRepository vr = new VaardigheidRepository(vsc);

                ViewBag.vaardigheden = vr.GetAll();

                return View("~/Views/Hulpbehoevende/NieuweOpdracht.cshtml");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.Ajax.Utilities;

namespace CarespotASP.Controllers
{
    public class VrijwilligerController : Controller
    {
        // GET: Vrijwilliger
        public ActionResult Index()
        {
            try
            {
                HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
                HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

                List<Hulpvraag> hulpvragen = hvr.GetHulpvragenByVrijwilligerId(4);
                ViewBag.hulpvragen = hulpvragen;

                return View("~/Views/Vrijwilliger/Hoofdscherm.cshtml");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult OpdrachtOverzicht()
        {
            try
            {
                HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
                HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

                List<Hulpvraag> hulpvragen = hvr.GetHulpvragenByVrijwilligerId(4);
                ViewBag.hulpvragen = hulpvragen;

                return View("~/Views/Vrijwilliger/OpdrachtOverzicht.cshtml");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult Reageer(int id)
        {
            try
            {
                ViewBag.hulpvraagid = id;
                return View("~/Views/Vrijwilliger/Reageer.cshtml");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult CreateReactie(FormCollection form)
        {
            try
            {
                //Haal ingelogde gebruiker op
                var vrijwilliger = (Vrijwilliger) Session["LoggedInUser"];

                var reactie = new Reactie(
                    form["bericht"],
                    DateTime.Now,
                    vrijwilliger.Id,
                    Convert.ToInt32(form["id"]));

                ReactieSqlContext rsc = new ReactieSqlContext();
                ReactieRepository rr = new ReactieRepository(rsc);

                rr.CreateReactie(reactie);


                return RedirectToAction("Index", "Vrijwilliger");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }


    }
}
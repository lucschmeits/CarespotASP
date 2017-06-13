using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;
using Microsoft.Ajax.Utilities;

namespace CarespotASP.Controllers
{
    public class VrijwilligerController : Controller
    {
        // GET: Vrijwilliger
        public ActionResult Index()
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Vrijwilliger, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            var vrijwilliger = (Vrijwilliger)Session["LoggedInUser"];

            try
            {
                //Haal mijn opdrachten op
                List<Hulpvraag> hulpvragen = hvr.GetHulpvragenByVrijwilligerId(vrijwilliger.Id);
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
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Vrijwilliger, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            try
            {
                //Haal alle opdrachten op die nog geen vrijwilliger hebben.
                List<Hulpvraag> hulpvragen = hvr.GetHulpvragenZonderVrijwilliger();
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
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Vrijwilliger, (Gebruiker)Session["LoggedInUser"]))
            {
                return Redirect(Request.UrlReferrer.ToString());
            }

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
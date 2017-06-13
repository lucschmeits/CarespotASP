using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class HulpvraagController : Controller
    {
        // GET: Hulpvraag
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.All, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            try
            {
                HulpvraagSqlContext hsc = new HulpvraagSqlContext();
                HulpvraagRepository hr = new HulpvraagRepository(hsc);
                Hulpvraag hulpvrg = hr.GetById(id);


            ReactieSqlContext rsc = new ReactieSqlContext();
            ReactieRepository rr = new ReactieRepository(rsc);

            List<Reactie> reacties = rr.GetReatiesByHulpvraagId(id);
            ViewBag.reacties = reacties;

            return View(hulpvrg);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpPost]
        public ActionResult CreateOpdracht(FormCollection form)
        {

            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Hulpbehoevende, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }
            try
            {


                //Vervoerstype parsen
                VervoerType vervoerstype = (VervoerType) Enum.Parse(typeof(VervoerType), form["vervoertype"]);

                //Urgentie controleren
                bool urgent = false;

                if (form["urgent"] == "urgent")
                {
                    urgent = true;
                }

                //Haal de ingelogde gebruiker op
                var hulpbehoevende = (Hulpbehoevende) Session["LoggedInUser"];

                Hulpvraag hulpvraag = new Hulpvraag(
                    form["titel"],
                    form["beschrijving"],
                    DateTime.Parse(form["opdrachtdatum"]),
                    DateTime.Now,
                    form["locatie"],
                    urgent,
                    vervoerstype,
                    false,
                    hulpbehoevende
                );

                if (form["vaardigheden[]"] != null)
                {
                    string s = form["vaardigheden[]"];

                    if (s != null)
                    {
                        int[] vaardighedenids = Array.ConvertAll(s.Split(','), int.Parse);

                        hulpvraag.Vaardigheden = new List<Vaardigheid>();

                        foreach (int id in vaardighedenids)
                        {
                            Vaardigheid vaardigheid = new Vaardigheid(id);
                            hulpvraag.Vaardigheden.Add(vaardigheid);
                        }
                    }
                }

                HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
                HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

                hvr.Create(hulpvraag);

                return RedirectToAction("Index", "Hulpbehoevende");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult DeleteHulpvraag(int id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.All, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }
            try
            {
                HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
                HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

                hvr.Delete(id);

                return RedirectToAction("Index", "Hulpbehoevende");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult AcceptHulpvraag(int id)
        {
           ReactieSqlContext rc = new ReactieSqlContext();
           ReactieRepository rr = new ReactieRepository(rc);

            rr.AcceptHulpvraag(id);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString()); //Return terug naar waar je vandaan komt.
        }

        [HttpGet]
        public ActionResult DeclineHulpvraag(int id)
        {
            ReactieSqlContext rc = new ReactieSqlContext();
            ReactieRepository rr = new ReactieRepository(rc);

            rr.DeclineHulpvraag(id);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString()); //Return terug naar waar je vandaan komt.
        }
    }
}
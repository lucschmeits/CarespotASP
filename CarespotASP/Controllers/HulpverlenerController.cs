﻿using System;
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
    public class HulpverlenerController : Controller
    {
        // GET: Hulpverlener

        public ActionResult Index()
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Hulpverlener, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            try
            {
                Hulpverlener loggedInHulpverlener = (Hulpverlener) Session["LoggedInUser"];

                if (loggedInHulpverlener != null)
                {
                    HulpbehoevendeSqlContext hsc = new HulpbehoevendeSqlContext();
                    HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

                    //Alle hulpbehoevenden
                    ViewBag.HulpBehoevenden = hr.GetHulpbehoevendenByHulpverlenerId(loggedInHulpverlener.Id);
                    return View("~/Views/Hulpverlener/Hulpverlener.cshtml");
                }
                else
                {
                    return View("~/Views/Login/Login.cshtml");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        public ActionResult Opdrachten(string id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Hulpverlener, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }
            try
            {
                Hulpverlener loggedInHulpverlener = (Hulpverlener) Session["LoggedInUser"];

                if (loggedInHulpverlener != null)
                {

                    HulpbehoevendeSqlContext hsc = new HulpbehoevendeSqlContext();
                    HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

                    HulpvraagSqlContext hulpvraagsc = new HulpvraagSqlContext();
                    HulpvraagRepository hulpvraagr = new HulpvraagRepository(hulpvraagsc);

                    //Alle hulpbehoevenden
                    ViewBag.HulpBehoevenden = hr.GetHulpbehoevendenByHulpverlenerId(loggedInHulpverlener.Id);


                    //Opdrachten van hulpbehoevenden
                    ViewBag.hulpvragen = hulpvraagr.GetHulpvragenByHulpbehoevendeId(Convert.ToInt32(id));

                    return View("~/Views/Hulpverlener/Hulpverlener.cshtml");
                }
                else
                {
                    return View("~/Views/Login/Login.cshtml");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
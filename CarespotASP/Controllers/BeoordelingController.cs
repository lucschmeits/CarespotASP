using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class BeoordelingController : Controller
    {
        // GET: Beoordeling
        public ActionResult Index()
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.All, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            return View("NieuwBeoordeling");
        }
    }
}
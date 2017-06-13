using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Gebruiker loggedInUser = (Gebruiker)Session["LoggedInUser"];



            if (loggedInUser == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else if (loggedInUser.GetType().Name == "Hulpbehoevende")
            {
                return RedirectToAction("Index", "Hulpbehoevende");
            }
            else if (loggedInUser.GetType().Name == "Beheerder")
            {
                return RedirectToAction("Index", "Beheerder");
            }
            else if (loggedInUser.GetType().Name == "Hulpverlener")
            {
                return RedirectToAction("Index", "Hulpverlener");
            }
            else if (loggedInUser.GetType().Name == "Vrijwilliger")
            {
                return RedirectToAction("Index", "Vrijwilliger");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }

  /*      public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        */
    }
}
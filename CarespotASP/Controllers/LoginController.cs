using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        //Post Login
        [HttpPost]
        public ActionResult LoginPost(FormCollection loginForm)
        {
            Gebruiker g = AuthRepository.CheckAuth(loginForm["email"], loginForm["wachtwoord"]);

            if (g == null)
            {

                ViewBag.LoginResult = false;
                return View("~/Views/Login/Login.cshtml");
            }
            else
            {

                // Ga naar keuze scherm~!!!!
                return View("~/Views/Home/Index.cshtml");
            }


        }



        public ActionResult Keuze()
        {
            return View();
        }
    }
}
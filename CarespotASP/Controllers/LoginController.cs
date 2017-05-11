using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarespotASP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string email, string wachtwoord)
        {
            return View("Login");
        }

        public ActionResult Keuze()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;

namespace CarespotASP.Controllers
{
    public class GebruikerController : Controller
    {
        // GET: Gebruiker
        public ActionResult Index()
        {
            return View("NieuwGebruiker");
        }

        //Get /Details/{id}
        public ActionResult Details(int id)
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            ReviewSqlContext rsc = new ReviewSqlContext();
            ReviewRepository rr = new ReviewRepository(rsc);

            ViewBag.SelectedUser = gr.GetById(id);
            ViewBag.Reviews = rr.GetReviewByVrijwilligerId(id);
            return View("~/Views/Gebruiker/Details.cshtml");
        }
    }
}
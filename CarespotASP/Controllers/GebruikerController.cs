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
    public class GebruikerController : Controller
    {
        // GET: Gebruiker
        public ActionResult Index()
        {
            return View("NieuwGebruiker");
        }
        
        public ActionResult Gegevens(int id)
        {
            var sql = new GebruikerSqlContext();
            var repo = new GebruikerRepository(sql);
            var vsql = new VaardigheidSqlContext();
            var vrepo = new VaardigheidRepository(vsql);
            ViewData["vaardigheden"] = vrepo.GetAll();
            var gebruiker = 
                (from gebruikers in repo.GetUserWithType()
                where gebruikers.Id == id
                select gebruikers).First();
            ViewData["gebruiker"] = gebruiker;
            return View("GegevensWijzigen");
        }

        public ActionResult Update(FormCollection form, HttpPostedFileBase foto, int id)
        {
            var sql = new GebruikerSqlContext();
            var repo = new GebruikerRepository(sql);
            var vsql = new VrijwilligerSqlContext();
            var vrepo = new VrijwilligerRepository(vsql);
            var gebruiker = new Gebruiker();
            gebruiker.Id = id;
            byte[] array = new byte[0];
            if (foto != null)
            {
                if (foto.ContentLength > 0)
                {
                    var fileBytes = new byte[foto.ContentLength];
                    foto.InputStream.Read(fileBytes, 0, fileBytes.Length);
                    array = fileBytes;
                    gebruiker.Image = array;
                }

            }
            if (form["wachtwoord"] == form["wachtwoordnieuw"])
            {
                gebruiker.Wachtwoord = form["wachtwoord"];
            }
            gebruiker.Geslacht = (Geslacht) Enum.Parse(typeof(Geslacht), form["geslacht"]);
            gebruiker.Adres = form["adres"];
            gebruiker.Email = form["email"];
            gebruiker.Geboortedatum = Convert.ToDateTime(form["geboortedatum"]);
            gebruiker.Woonplaats = form["plaats"];
            gebruiker.Land = form["land"];
            gebruiker.Postcode = form["postcode"];
            gebruiker.Telefoonnummer = form["telnr"];
            gebruiker.Gebruikersnaam = form["gebruikersnaam"];
            gebruiker.Naam = form["naam"];
            gebruiker.HeeftAuto = bool.Parse(form["auto"]);
            gebruiker.HeeftRijbewijs = bool.Parse(form["rijbewijs"]);
            gebruiker.HeeftOv = bool.Parse(form["ov"]);
            gebruiker.Barcode = form["barcode"];

            var vaardigheidIds = form.GetValues("vaardigheden");
            var vaardigheidIdList = new List<int>();
            if (vaardigheidIds != null)
            {
                foreach (var vaardigheidId in vaardigheidIds)
                {
                    vaardigheidIdList.Add(Convert.ToInt32(vaardigheidId));
                }
            }
            if (vaardigheidIdList.Count != 0)
            {
                vrepo.CreateVrijwilligerWithVaardigheid(gebruiker.Id, vaardigheidIdList);
            }
            repo.Update(gebruiker);

            return View("GegevensWijzigen");
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
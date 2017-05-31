using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class RegistreerController : Controller
    {
        // GET: Registreer
        public ActionResult Index()
        {
            return View("Registreer");
        }

        public ActionResult Save(FormCollection form, HttpPostedFileBase foto, HttpPostedFileBase vog)
        {
            byte[] array = new byte[0];
            if (foto != null)
            {
                if (foto.ContentLength > 0)
                {
                    var fileBytes = new byte[foto.ContentLength];
                    foto.InputStream.Read(fileBytes, 0, fileBytes.Length);
                    array = fileBytes;

                }

            }
            
            var gebruiker1 = new Gebruiker();
            gebruiker1.Image = array;
            gebruiker1.Geslacht = (Geslacht) Enum.Parse(typeof(Geslacht), form["geslacht"]);
            gebruiker1.Adres = form["adres"];
            gebruiker1.Email = form["email"];
            gebruiker1.Geboortedatum = Convert.ToDateTime(form["geboortedatum"]);
            gebruiker1.Woonplaats = form["plaats"];
            gebruiker1.Land = form["land"];
            gebruiker1.Postcode = form["postcode"];
            gebruiker1.Telefoonnummer = form["telnr"];
           // gebruiker1.Huisnummer = form["huisnr"];
            gebruiker1.Wachtwoord = form["wachtwoord"];
            gebruiker1.Gebruikersnaam = form["gebruikersnaam"];
            gebruiker1.Naam = form["naam"];
            gebruiker1.HeeftAuto = bool.Parse(form["auto"]);
            gebruiker1.HeeftRijbewijs = bool.Parse(form["rijbewijs"]);
            gebruiker1.HeeftOv = bool.Parse(form["ov"]);
            gebruiker1.Barcode = "123";

           
            var sql = new GebruikerSqlContext();
            var repo = new GebruikerRepository(sql);
            int id = repo.Create(gebruiker1);
            var vrijwilliger = new Vrijwilliger(id, vog.FileName, false);
            var vsql = new VrijwilligerSqlContext();
            var vrepo = new VrijwilligerRepository(vsql);
            vrepo.Create(vrijwilliger.Id, vrijwilliger.VOG);

            return RedirectToAction("Index", "Login");
        }
    }
}
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
            var vsql = new VaardigheidSqlContext();
            var vrepo = new VaardigheidRepository(vsql);
            ViewData["vaardigheden"] = vrepo.GetAll();
            return View("Registreer");
        }

        public ActionResult Save(FormCollection form, HttpPostedFileBase foto, HttpPostedFileBase vog)
        {
            var vogPath = "";
            var path = "";
            if (vog != null)
            {
                if (vog.ContentLength > 0)
                {
                    if (Path.GetExtension(vog.FileName).ToLower() == ".pdf")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/VOG"), vog.FileName);
                        vog.SaveAs(path);
                        vogPath = "../../Content/VOG/" + vog.FileName;
                    }
                }
            }
            var fotoPath = "";
            if (foto != null)
            {
                if (foto.ContentLength > 0)
                {
                    if (Path.GetExtension(foto.FileName).ToLower() == ".png" || Path.GetExtension(foto.FileName).ToLower() == ".jpg" ||
                        Path.GetExtension(foto.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Foto"), foto.FileName);
                        foto.SaveAs(path);
                        fotoPath = "../../Content/Foto/" + foto.FileName;
                    }
                   

                }

            }
            if (form["vrij"] == null && form["hulp"] == null)
            {
                return RedirectToAction("Index", "Registreer");
            }
            if (form["wachtwoord"] == form["wachtwoordherhalen"])
            {
                var gebruiker1 = new Gebruiker();
                gebruiker1.Image = fotoPath;
                gebruiker1.Geslacht = (Geslacht)Enum.Parse(typeof(Geslacht), form["geslacht"]);
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
                gebruiker1.Barcode = form["barcode"];

                var vaardigheidIds = form.GetValues("vaardigheden");
                var vaardigheidIdList = new List<int>();
                if (vaardigheidIds != null)
                {
                    foreach (var vaardigheidId in vaardigheidIds)
                    {
                        vaardigheidIdList.Add(Convert.ToInt32(vaardigheidId));
                    }
                }

                var sql = new GebruikerSqlContext();
                var repo = new GebruikerRepository(sql);
                int id = repo.Create(gebruiker1);
                if (form["hulp"] != null && form["hulp"].ToString() == "hulpbehoevende")
                {
                    var hulpbehoevende = new Hulpbehoevende(id);
                    hulpbehoevende.Id = id;
                    var hsql = new HulpbehoevendeSqlContext();
                    var hrepo = new HulpbehoevendeRepository(hsql);
                    hrepo.CreateHulpbehoevende(hulpbehoevende.Id, hrepo.BepaalHulpverlener());
                }

                if (form["vrij"] != null && form["vrij"].ToString() == "vrijwilliger")
                {
                    var vrijwilliger = new Vrijwilliger(id, vogPath, false);
                    var vsql = new VrijwilligerSqlContext();
                    var vrepo = new VrijwilligerRepository(vsql);
                    vrepo.Create(vrijwilliger.Id, vrijwilliger.VOG);
                    if (vaardigheidIdList.Count != 0)
                    {
                        vrepo.CreateVrijwilligerWithVaardigheid(vrijwilliger.Id, vaardigheidIdList);
                    }
                    
                }

              

                return RedirectToAction("Index", "Login");
            }


            return RedirectToAction("Index", "Registreer");

        }

        public ActionResult Beheerder()
        {
            return View("RegistreerBeheerderHulpverlener");
        }
        public ActionResult SaveBeheerHulp(FormCollection form, HttpPostedFileBase foto)
        {
            var path = "";
            var fotoPath = "";
            if (foto != null)
            {
                if (foto.ContentLength > 0)
                {
                    if (Path.GetExtension(foto.FileName).ToLower() == ".png" || Path.GetExtension(foto.FileName).ToLower() == ".jpg" ||
                        Path.GetExtension(foto.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Foto"), foto.FileName);
                        foto.SaveAs(path);
                        fotoPath = "../../Content/Foto/" + foto.FileName;
                    }


                }

            }
            if (form["radio"] == null)
            {
                return RedirectToAction("Index", "Registreer");
            }
            if (form["wachtwoord"] == form["wachtwoordherhalen"])
            {
                var gebruiker1 = new Gebruiker();
                gebruiker1.Image = fotoPath;
                gebruiker1.Geslacht = (Geslacht)Enum.Parse(typeof(Geslacht), form["geslacht"]);
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
                //gebruiker1.HeeftAuto = bool.Parse(form["auto"]);
                //gebruiker1.HeeftRijbewijs = bool.Parse(form["rijbewijs"]);
                //gebruiker1.HeeftOv = bool.Parse(form["ov"]);
                gebruiker1.Barcode = form["barcode"];


                var sql = new GebruikerSqlContext();
                var repo = new GebruikerRepository(sql);
                int id = repo.Create(gebruiker1);
                if (form["radio"] != null && form["radio"].ToString() == "Beheerder")
                {
                   var beheerder = new Beheerder(id);
                   var bsql = new BeheerderSqlContext();
                    var brepo = new BeheerderRepository(bsql);
                    brepo.Create(id);

                }

                if (form["radio"] != null && form["radio"].ToString() == "Hulpverlener")
                {
                   var hulpverlener = new Hulpverlener(id);
                    var hsql = new HulpverlenerSqlContext();
                    var hrepo = new HulpverlenerRepository(hsql);
                    hrepo.Create(id);

                }



                return RedirectToAction("Index", "Login");
            }


            return RedirectToAction("Index", "Registreer");
        }
    }
}
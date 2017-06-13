using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                VaardigheidSqlContext vsql = new VaardigheidSqlContext();
                VaardigheidRepository vrepo = new VaardigheidRepository(vsql);
                ViewData["vaardigheden"] = vrepo.GetAll();
                return View("Registreer");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Save(FormCollection form, HttpPostedFileBase foto, HttpPostedFileBase vog)
        {
            try
            {
                string vogPath = "";
                string path = "";
                if (vog != null)
                {
                    if (vog.ContentLength > 0)
                    {
                        if (Path.GetExtension(vog.FileName).ToLower() == ".pdf")
                        {
                            path = Path.Combine(Server.MapPath("~/Content/VOG"), vog.FileName);
                            vog.SaveAs(path);
                            vogPath = "~/Content/VOG/" + vog.FileName;
                        }
                    }
                }
                string fotoPath = "";
                if (foto != null)
                {
                    if (foto.ContentLength > 0)
                    {
                        if (Path.GetExtension(foto.FileName).ToLower() == ".png" ||
                            Path.GetExtension(foto.FileName).ToLower() == ".jpg" ||
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
                    Gebruiker gebruiker1 = new Gebruiker();
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

                    string[] vaardigheidIds = form.GetValues("vaardigheden");
                    List<int> vaardigheidIdList = new List<int>();
                    if (vaardigheidIds != null)
                    {
                        foreach (string vaardigheidId in vaardigheidIds)
                            vaardigheidIdList.Add(Convert.ToInt32(vaardigheidId));
                    }

                    GebruikerSqlContext sql = new GebruikerSqlContext();
                    GebruikerRepository repo = new GebruikerRepository(sql);
                    int id = repo.Create(gebruiker1);
                    if (form["hulp"] != null && form["hulp"] == "hulpbehoevende")
                    {
                        Hulpbehoevende hulpbehoevende = new Hulpbehoevende(id);
                        hulpbehoevende.Id = id;
                        HulpbehoevendeSqlContext hsql = new HulpbehoevendeSqlContext();
                        HulpbehoevendeRepository hrepo = new HulpbehoevendeRepository(hsql);
                        hrepo.CreateHulpbehoevende(hulpbehoevende.Id, hrepo.BepaalHulpverlener());
                    }

                    if (form["vrij"] != null && form["vrij"] == "vrijwilliger")
                    {
                        Vrijwilliger vrijwilliger = new Vrijwilliger(id, vogPath, false);
                        VrijwilligerSqlContext vsql = new VrijwilligerSqlContext();
                        VrijwilligerRepository vrepo = new VrijwilligerRepository(vsql);
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
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Beheerder()
        {
            return View("RegistreerBeheerderHulpverlener");
        }

        public ActionResult RegistreerHulpverlener()
        {
            return View("RegistreerHulpverlener");
        }

        [HttpPost]
        public ActionResult RegistreerHulpverlener(FormCollection form, HttpPostedFileBase foto)
        {
            try
            {
                string path = "";
                string fotoPath = "";
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
                if (form["wachtwoord"] == form["wachtwoordherhalen"])
                {
                    Gebruiker gebruiker1 = new Gebruiker();
                    gebruiker1.Image = fotoPath;
                    gebruiker1.Geslacht = (Geslacht)Enum.Parse(typeof(Geslacht), form["geslacht"]);
                    gebruiker1.Adres = form["adres"];
                    gebruiker1.Email = form["email"];
                    gebruiker1.Geboortedatum = Convert.ToDateTime(form["geboortedatum"]);
                    gebruiker1.Woonplaats = form["plaats"];
                    gebruiker1.Land = form["land"];
                    gebruiker1.Postcode = form["postcode"];
                    gebruiker1.Telefoonnummer = form["telnr"];
                    gebruiker1.Wachtwoord = form["wachtwoord"];
                    gebruiker1.Gebruikersnaam = form["gebruikersnaam"];
                    gebruiker1.Naam = form["naam"];
                    gebruiker1.Barcode = form["barcode"];

                    GebruikerSqlContext sql = new GebruikerSqlContext();
                    GebruikerRepository repo = new GebruikerRepository(sql);
                    int id = repo.Create(gebruiker1);
                    Hulpverlener hulpverlener = new Hulpverlener(id);
                    HulpverlenerSqlContext hsql = new HulpverlenerSqlContext();
                    HulpverlenerRepository hrepo = new HulpverlenerRepository(hsql);
                    hrepo.Create(id);

                    return RedirectToAction("Index", "Login");
                }
                return RedirectToAction("RegistreerHulpverlener", "Registreer");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult SaveBeheerHulp(FormCollection form, HttpPostedFileBase foto)
        {
            try
            {
                string path = "";
                string fotoPath = "";
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
                    Gebruiker gebruiker1 = new Gebruiker();
                    gebruiker1.Image = fotoPath;
                    gebruiker1.Geslacht = (Geslacht)Enum.Parse(typeof(Geslacht), form["geslacht"]);
                    gebruiker1.Adres = form["adres"];
                    gebruiker1.Email = form["email"];
                    gebruiker1.Geboortedatum = Convert.ToDateTime(form["geboortedatum"]);
                    gebruiker1.Woonplaats = form["plaats"];
                    gebruiker1.Land = form["land"];
                    gebruiker1.Postcode = form["postcode"];
                    gebruiker1.Telefoonnummer = form["telnr"];
                    gebruiker1.Wachtwoord = form["wachtwoord"];
                    gebruiker1.Gebruikersnaam = form["gebruikersnaam"];
                    gebruiker1.Naam = form["naam"];
                    gebruiker1.Barcode = form["barcode"];

                    GebruikerSqlContext sql = new GebruikerSqlContext();
                    GebruikerRepository repo = new GebruikerRepository(sql);
                    int id = repo.Create(gebruiker1);
                    if (form["radio"] != null && form["radio"] == "Beheerder")
                    {
                        Beheerder beheerder = new Beheerder(id);
                        BeheerderSqlContext bsql = new BeheerderSqlContext();
                        BeheerderRepository brepo = new BeheerderRepository(bsql);
                        brepo.Create(id);
                    }

                    if (form["radio"] != null && form["radio"] == "Hulpverlener")
                    {
                        Hulpverlener hulpverlener = new Hulpverlener(id);
                        HulpverlenerSqlContext hsql = new HulpverlenerSqlContext();
                        HulpverlenerRepository hrepo = new HulpverlenerRepository(hsql);
                        hrepo.Create(id);
                    }

                    return RedirectToAction("Index", "Login");
                }

                return RedirectToAction("Index", "Registreer");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
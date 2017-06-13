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
    public class GebruikerController : Controller
    {
        // GET: Gebruiker
        public ActionResult Index()
        {
            return View("NieuwGebruiker");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Gegevens(int id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.All, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            try
            {
                GebruikerSqlContext sql = new GebruikerSqlContext();
                GebruikerRepository repo = new GebruikerRepository(sql);
                VaardigheidSqlContext vsql = new VaardigheidSqlContext();
                VaardigheidRepository vrepo = new VaardigheidRepository(vsql);
                ViewData["vaardigheden"] = vrepo.GetAll();
                Gebruiker gebruiker =
                (from gebruikers in repo.GetUserWithType()
                 where gebruikers.Id == id
                 select gebruikers).First();
                ViewData["gebruiker"] = gebruiker;
                return View("GegevensWijzigen");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Update(FormCollection form, int id, HttpPostedFileBase foto)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.All, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            try
            {
                if (Session["LoggedInUser"] != null)
                {
                    Gebruiker loggedinGebruiker = Session["LoggedInUser"] as Gebruiker;
                    GebruikerSqlContext sql = new GebruikerSqlContext();
                    GebruikerRepository repo = new GebruikerRepository(sql);
                    VrijwilligerSqlContext vsql = new VrijwilligerSqlContext();
                    VrijwilligerRepository vrepo = new VrijwilligerRepository(vsql);
                    Gebruiker gebruiker = new Gebruiker();
                    gebruiker.Id = id;
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
                                fotoPath = "/Content/Foto/" + foto.FileName;
                                gebruiker.Image = fotoPath;
                            }
                        }
                    }
                    else
                    {
                        gebruiker.Image = loggedinGebruiker.Image;
                    }
                    if (form["wachtwoord"] != "" && form["wachtwoordnieuw"] != "")
                    {
                        if (form["wachtwoord"] == form["wachtwoordnieuw"])
                        {
                            gebruiker.Wachtwoord = form["wachtwoord"];
                        }
                    }
                    else
                    {
                        gebruiker.Wachtwoord = loggedinGebruiker.Wachtwoord;
                    }

                    gebruiker.Geslacht = (Geslacht)Enum.Parse(typeof(Geslacht), form["geslacht"]);
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

                    string[] vaardigheidIds = form.GetValues("vaardigheden");
                    List<int> vaardigheidIdList = new List<int>();
                    if (vaardigheidIds != null)
                    {
                        foreach (string vaardigheidId in vaardigheidIds)
                            vaardigheidIdList.Add(Convert.ToInt32(vaardigheidId));
                    }
                    if (vaardigheidIdList.Count != 0)
                    {
                        vrepo.CreateVrijwilligerWithVaardigheid(gebruiker.Id, vaardigheidIdList);
                    }
                    repo.Update(gebruiker);

                    return RedirectToAction("Gegevens", "Gebruiker", new { id = gebruiker.Id });
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        //Get /Details/{id}
        public ActionResult Details(int id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.All, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            //  try {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            ReviewSqlContext rsc = new ReviewSqlContext();
            ReviewRepository rr = new ReviewRepository(rsc);

            Gebruiker loggedUser = (Gebruiker)Session["LoggedInUser"];

            ViewBag.SelectedUser = gr.GetById(id);

            if (loggedUser != null)
            {
                ViewBag.CanReview = rr.CanReview(loggedUser.Id, id);
            }

            ViewBag.SelectedUser = gr.GetById(id);
            ViewBag.Reviews = rr.GetReviewByVrijwilligerId(id);
            return View("~/Views/Gebruiker/Details.cshtml");
            // }

            /*
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
            */
        }

        public ActionResult Delete(int id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.All, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }
            try
            {
                GebruikerSqlContext gsql = new GebruikerSqlContext();
                GebruikerRepository grepo = new GebruikerRepository(gsql);
                grepo.Delete(id);
                Gebruiker gebruiker = (Gebruiker)Session["LoggedInUser"];
                if (gebruiker.GetType() == typeof(Beheerder))
                {
                    return RedirectToAction("Index", "Beheerder");
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
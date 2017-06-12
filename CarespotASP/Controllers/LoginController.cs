using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

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
            try
            {
                Gebruiker g = AuthRepository.CheckAuth(loginForm["email"], loginForm["wachtwoord"]);
                GebruikerSqlContext gsc = new GebruikerSqlContext();
                GebruikerRepository gr = new GebruikerRepository(gsc);

                if (g == null)
                {
                    ViewBag.LoginResult = false;
                    return View("~/Views/Login/Login.cshtml");
                }
                else
                {
                    List<Gebruiker> users = gr.GetUserTypesByUserId(g.Id);
                    List<GebruikerType> types = new List<GebruikerType>();

                    foreach (Gebruiker gebr in users)
                    {
                        types.Add((GebruikerType) Enum.Parse(typeof(GebruikerType), gebr.GetType().Name));
                    }

                    if (types.Contains(GebruikerType.Hulpbehoevende) && types.Contains(GebruikerType.Vrijwilliger))
                    {
                        ViewBag.Accounts = users;
                        ViewBag.Types = types;

                        return View("~/Views/Login/Keuze.cshtml");
                    }
                    else if (types.Contains(GebruikerType.Hulpbehoevende))
                    {
                        HulpbehoevendeSqlContext hsc = new HulpbehoevendeSqlContext();
                        HulpbehoevendeRepository hr = new HulpbehoevendeRepository(hsc);

                        Session["LoggedInUser"] = hr.GetHulpbehoevendeById(g.Id);
                        return RedirectToAction("Index", "Hulpbehoevende");
                    }
                    else if (types.Contains(GebruikerType.Vrijwilliger))
                    {
                        VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
                        VrijwilligerRepository vr = new VrijwilligerRepository(vsc);
                        Session["LoggedInUser"] = vr.GetVrijwilligerById(g.Id);
                        return RedirectToAction("Index", "Vrijwilliger");
                    }
                    else if (types.Contains(GebruikerType.Beheerder))
                    {
                        BeheerderSqlContext bsc = new BeheerderSqlContext();
                        BeheerderRepository br = new BeheerderRepository(bsc);
                        Session["LoggedInUser"] = br.GetById(g.Id);
                        return RedirectToAction("Index", "Beheerder");
                    }
                    else if (types.Contains(GebruikerType.Hulpverlener))
                    {
                        HulpverlenerSqlContext hsc = new HulpverlenerSqlContext();
                        HulpverlenerRepository hr = new HulpverlenerRepository(hsc);
                        Session["LoggedInUser"] = hr.GetById(g.Id);
                        return RedirectToAction("Index", "Hulpverlener");
                    }
                    return RedirectToAction("Index", "Login");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Keuze()
        {
            return View();
        }
    }
}
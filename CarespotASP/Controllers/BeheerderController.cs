using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;
using CarespotASP.Views.Beheerder;

namespace CarespotASP.Controllers
{
    public class BeheerderController : Controller
    {
        // GET: Beheerder
        public ActionResult Index()
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Beheerder, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            try
            {
                BeheerderViewModel model = new BeheerderViewModel();

                HulpvraagSqlContext hsc = new HulpvraagSqlContext();
                HulpvraagRepository hr = new HulpvraagRepository(hsc);

                GebruikerSqlContext gsc = new GebruikerSqlContext();
                GebruikerRepository gr = new GebruikerRepository(gsc);

                model.LstGebruiker = gr.GetUserWithType();
                model.LstHulpvraag = hr.GetAll();

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Beheerder/Details/5
        public ActionResult Details(int id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Beheerder, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }

            try
            {
                HulpvraagSqlContext hsc = new HulpvraagSqlContext();
                HulpvraagRepository hr = new HulpvraagRepository(hsc);
                Hulpvraag hulpvrg = hr.GetById(id);
                return View(hulpvrg);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Accepteer(int id)
        {
            if (!AuthRepository.CheckIfUserCanAcces(GebruikerType.Beheerder, (Gebruiker)Session["LoggedInUser"]))
            {
                return View("~/Views/Error/AuthError.cshtml");
            }
            try
            {
                var vsql = new VrijwilligerSqlContext();
                var vrepo = new VrijwilligerRepository(vsql);
                vrepo.UpdateVrijwilliger(id, true);
                return RedirectToAction("Index", "Beheerder");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
            
        }

        // GET: Beheerder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beheerder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beheerder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beheerder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beheerder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beheerder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //Get: Beheerder/Chat
        public ActionResult Chat(FormCollection f)
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            ChatSqlContext csc = new ChatSqlContext();
            ChatRepository cr = new ChatRepository(csc);

            List<Gebruiker> users = gr.GetAll();


            int id1 = Convert.ToInt32(f["user1"]);
            int id2 = Convert.ToInt32(f["user2"]);



            if (id1 != 0 && id2 != 0 && (id1 != id2))
            {
                List<Chat> chat = cr.GetChatByUsers(id1, id2);
                string chatString = "";

                if (chat.Count > 0)
                {
                    for (int i = 0; i < chat.Count; i++)
                    {
                        chatString = chatString + chat[i].Auteur.Naam + " | " + chat[i].Bericht + "\r";
                    }

                    ViewBag.Chatstring = chatString;
                }
                else
                {
                    ViewBag.Chatstring = "Geen chat gevonden";
                }

               
            }
            else
            {
                ViewBag.Chatstring = "" ;
            }


            ViewBag.Users = users;

            return View("~/Views/Chat/Beheer.cshtml");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            try { 
                GebruikerSqlContext gsc = new GebruikerSqlContext();
                GebruikerRepository gr = new GebruikerRepository(gsc);

                ViewBag.Gebruikers = gr.GetAll();
                return View("~/Views/Chat/Index.cshtml");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }


        //GET : Chat/{AnderegebruikerId}

        public ActionResult ChatScherm(string id)
        {
            try
            {
                GebruikerSqlContext gsc = new GebruikerSqlContext();
                GebruikerRepository gr = new GebruikerRepository(gsc);
                var sql = new ChatSqlContext();
                var chatRepo = new ChatRepository(sql);

                Gebruiker loggedInUser = (Gebruiker) Session["LoggedInUser"];
                //  Gebruiker loggedInUser = gr.GetById(1);

                ViewBag.LoggedInUser = loggedInUser;
                ViewBag.Gebruikers = gr.GetAll();
                ViewBag.EnableChat = "true";
                return View("~/Views/Chat/Index.cshtml");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }



        //Post : Chat/HaalChatOp
        [HttpPost]
        public JsonResult HaalChatOp(int userId1, int userId2)
        {
            try
            {
                var sql = new ChatSqlContext();
                var chatRepo = new ChatRepository(sql);
                return Json(chatRepo.GetChatByUsers(userId1, userId2));
            }
            catch (Exception e)
            {
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "Error"),
                    isRedirect = true
                });
            }
        }


        //Post: Chat/SendChatMessage
        [HttpPost]
        public JsonResult SendChatMessage(int autheurId, int ontvangerId, string bericht)
        {
            try
            {
                GebruikerSqlContext gsc = new GebruikerSqlContext();
                GebruikerRepository gr = new GebruikerRepository(gsc);
                var sql = new ChatSqlContext();
                var chatRepo = new ChatRepository(sql);

                Gebruiker auteur = gr.GetById(autheurId);
                Gebruiker ontvanger = gr.GetById(ontvangerId);
                Chat nieuwBericht = new Chat(auteur, ontvanger, DateTime.Now, bericht);
                chatRepo.Create(nieuwBericht);

                return null;
            }
            catch (Exception e)
            {
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "Error"),
                    isRedirect = true
                });
            }
        }

    }
}
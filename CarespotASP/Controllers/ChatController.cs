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
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            ViewBag.Gebruikers = gr.GetAll();
            return View("~/Views/Chat/Index.cshtml");
        }


        //GET : Chat/{AnderegebruikerId}

        public ActionResult ChatScherm(string id)
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);
            var sql = new ChatSqlContext();
            var chatRepo = new ChatRepository(sql);
      
         //   Gebruiker loggedInUser= (Gebruiker) Session["LoggedInUser"];
            Gebruiker loggedInUser = gr.GetById(1);
            
            ViewBag.LoggedInUser = loggedInUser;
            ViewBag.Gebruikers = gr.GetAll();
            ViewBag.EnableChat = "true";
            return View("~/Views/Chat/Index.cshtml");
        }



        //Post : Chat/HaalChatOp
        [HttpPost]
        public JsonResult HaalChatOp(int userId1, int userId2)
        {
            var sql = new ChatSqlContext();
            var chatRepo = new ChatRepository(sql);
            return Json(chatRepo.GetChatByUsers(userId1, userId2));
        }


        //Post: Chat/SendChatMessage
        [HttpPost]
        public JsonResult SendChatMessage(int autheurId, int ontvangerId, string bericht)
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

    }
}
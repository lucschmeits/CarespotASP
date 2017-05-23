using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class ChatRepository
    {
        private IChat _chatInterface;

        public ChatRepository(IChat chatInterface)
        {
            _chatInterface = chatInterface;
        }

        public List<Chat> GetAll()
        {
            return _chatInterface.GetAll();
        }

        public Chat GetById(int id)
        {
            return _chatInterface.GetById(id);
        }

        public void Create(Chat chat)
        {
            _chatInterface.Create(chat);
        }

        //void Update(Chat chat);

        public void Delete(int id)
        {
            _chatInterface.Delete(id);
        }

        public List<Chat> GetChatByUsers(int gebruikerId, int gebruiker2Id)
        {
            List<Chat> allChatMessages = this.GetAll();
            List<Chat> returnList = new List<Chat>();

            foreach (Chat bericht in allChatMessages)
            {
                if (bericht.Auteur.Id == gebruikerId && bericht.Ontvanger.Id == gebruiker2Id)
                {
                    returnList.Add(bericht);
                }
                else if (bericht.Auteur.Id == gebruiker2Id && bericht.Ontvanger.Id == gebruikerId)
                {
                    returnList.Add(bericht);
                }
        
            }
            returnList.Sort();

            return returnList;
        }

    }
}
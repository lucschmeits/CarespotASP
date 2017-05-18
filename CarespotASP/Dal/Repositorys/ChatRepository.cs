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
    }
}
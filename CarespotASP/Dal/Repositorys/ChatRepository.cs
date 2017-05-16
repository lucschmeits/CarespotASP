using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;

namespace CarespotASP.Dal.Repositorys
{
    public class ChatRepository
    {
        private IChat _chatInterface;

        public ChatRepository(IChat chatInterface)
        {
            _chatInterface = chatInterface;
        }
    }
}
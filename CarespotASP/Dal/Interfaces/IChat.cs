using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IChat
    {
        List<Chat> GetAll();

        Chat GetById(int id);

        void Create(Chat chat);

        //void Update(Chat chat);

        void Delete(int id);
    }
}
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

        Chat GetById();

        void Create(Chat chat);

        void Update(int id);

        void Delete(int id);
    }
}
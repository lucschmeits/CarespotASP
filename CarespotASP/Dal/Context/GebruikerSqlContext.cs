using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class GebruikerSqlContext : IGebruiker
    {
        public List<Gebruiker> GetAllGebruikers()
        {
            throw new NotImplementedException();
        }

        public Gebruiker GetGebruikerById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateGebruiker()
        {
            throw new NotImplementedException();
        }

        public void UpdateGebruiker()
        {
            throw new NotImplementedException();
        }

        public void DeleteGebruikerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
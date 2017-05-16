using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class GebruikerRepository
    {
        private IGebruiker _interface;
        public GebruikerRepository(IGebruiker i)
        {
            _interface = i;
        }

        public int Create(Gebruiker obj)
        {
            return _interface.CreateGebruiker(obj);
        }
        public List<Gebruiker> GetAll()
        {
            return _interface.GetAllGebruikers();
        }

        public Gebruiker GetById(int id)
        {
            return _interface.GetGebruikerById(id);
        }

        public void Update(Gebruiker obj)
        {
            _interface.UpdateGebruiker(obj);
        }

        public void Delete(int id)
        {
            _interface.DeleteGebruikerById(id);
        }
    }
}
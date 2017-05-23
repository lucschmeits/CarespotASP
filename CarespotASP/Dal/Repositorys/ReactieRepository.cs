using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Models;
using CarespotASP.Dal.Interfaces;

namespace CarespotASP.Dal.Repositorys
{
    public class ReactieRepository
    {
        private readonly IReactie _interface;
        public ReactieRepository(IReactie i)
        {
            _interface = i;
        }
        public List<Reactie> GetAllReacties()
        {
            return _interface.GetAllReacties();
        }
        public Reactie GetReactieById(int id)
        {
            return _interface.GetReactieById(id);
        }
        public int CreateReactie(Reactie reactie)
        {
            return _interface.CreateReactie(reactie);
        }
        public void DeleteReactieById(int id)
        {
            _interface.DeleteReactieById(id);
        }

        public List<Reactie> GetReatiesByHulpvraagId(int hulpvraagId)
        {
         return this.GetAllReacties().Where(r => r.HulpvraagId == hulpvraagId).ToList();
        }
    }
}
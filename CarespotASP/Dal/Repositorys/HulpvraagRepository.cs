using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;


namespace CarespotASP.Dal.Repositorys
{
    public class HulpvraagRepository
    {
        private IHulpvraag _hulpvraagInterface;

        public HulpvraagRepository(IHulpvraag hulpvraagInterface)
        {
            _hulpvraagInterface = hulpvraagInterface;
        }

        public List<Hulpvraag> GetAll()
        {
            return _hulpvraagInterface.GetAll();
        }

        public Hulpvraag GetById(int id)
        {
            return _hulpvraagInterface.GetById(id);
        }

        public void Create(Hulpvraag hulpvraag)
        {
            _hulpvraagInterface.Create(hulpvraag);
        }

        public void Delete(int id)
        {
            _hulpvraagInterface.Delete(id);
        }

        public List<Hulpvraag> GetHulpvragenByVrijwilligerId(int vrijwilligerId)
        {
            return this.GetAll().Where(h => h.Vrijwilliger.Id == vrijwilligerId).ToList();

        }

        public List<Hulpvraag> GetHulpvragenByHulpbehoevendeId(int hulpbehoevendeId)
        {
            return this.GetAll().Where(h => h.Hulpbehoevende.Id == hulpbehoevendeId).ToList();

        }

    }
}
using System.Collections.Generic;
using System.Security.Policy;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class HulpbehoevendeRepository
    {
        private readonly IHulpbehoevende _interface;

        public HulpbehoevendeRepository(IHulpbehoevende i)
        {
            _interface = i;
        }

        public Hulpbehoevende GetHulpbehoevendeById(int id)
        {
            return _interface.GetHulpbehoevendeById(id);
        }

        public List<Hulpbehoevende> GetAllHulpbehoevenden()
        {
            return _interface.GetAllHulpbehoevenden();
        }

        public void CreateHulpbehoevende(int id, int hulpverleneId)
        {
            _interface.CreateHulpbehoevende(id, hulpverleneId);
        }

        public void DeleteHulpbehoevende(int id)
        {
            _interface.DeleteHulpbehoevendeById(id);
        }

        public int BepaalHulpverlener()
        {
            return _interface.BepaalHulpverlener();
        }

        public List<Hulpbehoevende> GetHulpbehoevendenByHulpverlenerId(int hulpverlenerId)
        {
            List<Hulpbehoevende> returnList = new List<Hulpbehoevende>();
            List<Hulpbehoevende> all = this.GetAllHulpbehoevenden();

            foreach (Hulpbehoevende h in all)
            {
                if (h.Hulpverlener.Id == hulpverlenerId)
                {
                    returnList.Add(h);
                }
            }

            return returnList;
        }

    }
}
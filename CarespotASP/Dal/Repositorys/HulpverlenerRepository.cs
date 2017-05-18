using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class HulpverlenerRepository
    {
        private IHulpverlener _hulpverlenerInterface;

        public HulpverlenerRepository(IHulpverlener hulpverlenerInterface)
        {
            _hulpverlenerInterface = hulpverlenerInterface;
        }

        public List<Hulpverlener> GetAll()
        {
            return _hulpverlenerInterface.GetAll();
        }

        public Hulpverlener GetById(int id)
        {
            return _hulpverlenerInterface.GetById(id);
        }

        public void Create(int id)
        {
            _hulpverlenerInterface.Create(id);
        }

        // void Update(Hulpverlener hulpverlener);

        public void Delete(int id)
        {
            _hulpverlenerInterface.Delete(id);
        }
    }
}
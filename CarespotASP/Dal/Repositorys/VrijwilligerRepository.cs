using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class VrijwilligerRepository
    {
        private IVrijwilliger _interface;


        public VrijwilligerRepository(IVrijwilliger i)
        {
            _interface = i;
        }

        public void Create(int gebruikerId, string vogPath)
        {
            _interface.CreateVrijwilliger(gebruikerId,vogPath);
        }


        public List<Vrijwilliger> GetAllVrijwilligers()
        {
            return _interface.GetAllVrijwilligers();
        }

        public Vrijwilliger GetVrijwilligerById(int id)
        {
            return _interface.GetVrijwilligerById(id);
        }

        public void UpdateVrijwilliger(int gebruikerId, string vogPath, bool isGoedgekeurd)
        {
            _interface.UpdateVrijwilliger(gebruikerId, vogPath, isGoedgekeurd);
        }

        public void DeleteVrijwillige(int id)
        {
            _interface.DeleteVrijwilligerById(id);
        }

        public void CreateVrijwilligerWithVaardigheid(int vrijwilligerId, List<int> vaardigheidList)
        {
            _interface.CreateVrijwilligerWithVaardigheid(vrijwilligerId, vaardigheidList);
        }
    }
}
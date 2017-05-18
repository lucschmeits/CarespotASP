using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IVrijwilliger
    {
        List<Vrijwilliger> GetAllVrijwilligers();

        Vrijwilliger GetVrijwilligerById(int id);

        void CreateVrijwilliger(int gebruikerId, string vogPath);

        void UpdateVrijwilliger(int gebruikerId, string vogPath, bool isGoedgekeurd);

        void DeleteVrijwilligerById(int id);
    }
}
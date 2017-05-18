using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    interface IVrijwilliger
    {
        List<Vrijwilliger> GetAllVrijwilligers();
        Vrijwilliger GetVrijwilligerById(int id);
        int CreateVrijwilliger();
        void UpdateVrijwilliger();
        void DeleteVrijwilligerById(int id);
    }
}

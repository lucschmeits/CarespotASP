using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IVaardigheid
    {
        List<Vaardigheid> GetAllVaardigheden();
        Vaardigheid GetVaardigheidById(int id);
        int CreateVaardigheid(Vaardigheid obj);
        void AddVaardigheidToHulpvraag(Vaardigheid vaardigheid, int hulpvraagid);
        void UpdateVaardigheid(Vaardigheid obj);
        void DeleteVaardigheidById(int id);
        List<Vaardigheid> GetVaardigheidByVrijwilligerId(int id);
        List<Vaardigheid> GetVaardigheidByHulpvraagId(int id);


    }
}

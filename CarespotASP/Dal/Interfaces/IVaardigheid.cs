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
        void UpdateVaardigheid(Vaardigheid obj);
        void DeleteVaardigheidById(int id);
    }
}

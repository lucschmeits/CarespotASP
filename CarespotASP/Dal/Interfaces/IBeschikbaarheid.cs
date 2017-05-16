using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IBeschikbaarheid
    {
        List<Beschikbaarheid> getAllBeschikbaarheid();
        Beschikbaarheid getBeschikbaarheidById(int Id);
        void CreateBeschikbaarheid(Beschikbaarheid obj);
        void UpdateBeschikbaarheid(Beschikbaarheid obj);
        void DeleteBeschikbaarheid(int Id);
    }
}

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
        List<Beschikbaarheid> GetAllBeschikbaarheid();
        Beschikbaarheid GetBeschikbaarheidById(int Id);
        int CreateBeschikbaarheid(Beschikbaarheid obj);
        void UpdateBeschikbaarheid(Beschikbaarheid obj);
        void DeleteBeschikbaarheid(int Id);
    }
}

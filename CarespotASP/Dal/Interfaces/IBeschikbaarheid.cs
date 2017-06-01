using System.Collections.Generic;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IBeschikbaarheid
    {
        List<Beschikbaarheid> GetAllBeschikbaarheid();

        Beschikbaarheid GetBeschikbaarheidById(int Id);

        //int CreateBeschikbaarheid(Beschikbaarheid obj);
        void UpdateBeschikbaarheid(Beschikbaarheid obj);

        void DeleteBeschikbaarheid(int Id);

        void Save(Beschikbaarheid beschikbaarheid, object obj);

        List<Beschikbaarheid> GetBeschikbaarheidByVrijwilligerId(int id);

        List<Beschikbaarheid> GetBeschikbaarheidByHulpvraagId(int id);
    }
}
using System.Collections.Generic;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IGebruiker
    {

        List<Gebruiker> GetAllGebruikers();
        Gebruiker GetGebruikerById(int id);
        int CreateGebruiker(Gebruiker obj);
        void UpdateGebruiker(Gebruiker obj);
        void DeleteGebruikerById(int id);
    }
}
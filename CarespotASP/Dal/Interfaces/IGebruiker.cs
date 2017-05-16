using System.Collections.Generic;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IGebruiker
    {

        List<Gebruiker> GetAllGebruikers();
        Gebruiker GetGebruikerById(int id);
        int CreateGebruiker();
        void UpdateGebruiker();
        void DeleteGebruikerById(int id);
    }
}
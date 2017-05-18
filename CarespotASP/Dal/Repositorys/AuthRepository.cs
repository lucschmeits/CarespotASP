using System.Collections.Generic;
using CarespotASP.Dal.Context;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public static class AuthRepository
    {

        public static Gebruiker CheckAuth(string email, string password)
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            List<Gebruiker> gebruikers = gr.GetAll();

            foreach (Gebruiker g in gebruikers)
            {
                if (g.Email == email && g.Wachtwoord == password)
                {
                    return g;
                }
            }
            return null;
        }


        public static Gebruiker CheckAuthBarcode(string barCode)
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            List<Gebruiker> gebruikers = gr.GetAll();

            foreach (Gebruiker g in gebruikers)
            {
                if (g.Barcode == barCode)
                {
                    return g;
                }
            }
            return null;
        }

    }
}
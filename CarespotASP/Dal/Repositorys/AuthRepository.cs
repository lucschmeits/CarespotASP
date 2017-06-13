using System;
using System.Collections.Generic;
using System.Web.ModelBinding;
using CarespotASP.Dal.Context;
using CarespotASP.Enums;
using CarespotASP.Models;
using System.Web;

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

        public static bool CheckIfUserCanAcces(GebruikerType rol, Gebruiker loggedUser)
        {
            if (loggedUser != null)
            {
                if (rol == GebruikerType.All)
                {
                    return true;
                }
                else if (loggedUser.GetType().Name == rol.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
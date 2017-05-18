using System;
using CarespotASP.Enums;

namespace CarespotASP.Models
{
    public class Hulpbehoevende : Gebruiker
    {
        public Hulpverlener Hulpverlener { get; set; }

        public Hulpbehoevende(int id, byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht, Hulpverlener hulpverlener) : base(id, image, email, wachtwoord, gebruikersnaam, naam, geboortedatum, heeftRijbewijs, heeftOv, heeftAuto, telefoonnummer, adres, woonplaats, land, postcode, geslacht)
        {
            Hulpverlener = hulpverlener;
        }

        public Hulpbehoevende(byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht, Hulpverlener hulpverlener) : base(image, email, wachtwoord, gebruikersnaam, naam, geboortedatum, heeftRijbewijs, heeftOv, heeftAuto, telefoonnummer, adres, woonplaats, land, postcode, geslacht)
        {
            Hulpverlener = hulpverlener;
        }

        public Hulpbehoevende(int id, Hulpverlener hulpverlener) : base(id)
        {
            Hulpverlener = hulpverlener;
        }
    }
}
using System;
using CarespotASP.Enums;

namespace CarespotASP.Models
{
    public class Beheerder : Gebruiker
    {
        public Beheerder(int id, byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht) : base(id, image, email, wachtwoord, gebruikersnaam, naam, geboortedatum, heeftRijbewijs, heeftOv, heeftAuto, telefoonnummer, adres, woonplaats, land, postcode, geslacht)
        {
        }

        public Beheerder(byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht) : base(image, email, wachtwoord, gebruikersnaam, naam, geboortedatum, heeftRijbewijs, heeftOv, heeftAuto, telefoonnummer, adres, woonplaats, land, postcode, geslacht)
        {
        }

        public Beheerder(int id) : base(id)
        {
        }
    }
}
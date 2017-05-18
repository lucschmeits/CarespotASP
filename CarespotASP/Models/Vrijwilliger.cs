﻿using System;
using CarespotASP.Enums;

namespace CarespotASP.Models
{
    public class Vrijwilliger : Gebruiker
    {
        public string VOG { get; set; }
        public bool IsGoedgekeurd { get; set; }

        public Vrijwilliger(int id, byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht, string vog, bool isGoedgekeurd) : base(id, image, email, wachtwoord, gebruikersnaam, naam, geboortedatum, heeftRijbewijs, heeftOv, heeftAuto, telefoonnummer, adres, woonplaats, land, postcode, geslacht)
        {
            VOG = vog;
            IsGoedgekeurd = isGoedgekeurd;
        }

        public Vrijwilliger(byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht, string vog, bool isGoedgekeurd) : base(image, email, wachtwoord, gebruikersnaam, naam, geboortedatum, heeftRijbewijs, heeftOv, heeftAuto, telefoonnummer, adres, woonplaats, land, postcode, geslacht)
        {
            VOG = vog;
            IsGoedgekeurd = isGoedgekeurd;
        }

        public Vrijwilliger(int id, string vog, bool isGoedgekeurd) : base(id)
        {
            VOG = vog;
            IsGoedgekeurd = isGoedgekeurd;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Enums;

namespace CarespotASP.Models
{
    public class Gebruiker
    {
        public int Id { get; private set; }

        public byte[] Image { get; private set; }

        public string Email { get; private set; }

        public string Wachtwoord { get; private set; }

        public string Gebruikersnaam { get; private set; }

        public string Naam { get; private set; }

        public DateTime Geboortedatum { get; private set; }

        public bool HeeftRijbewijs  { get; private set; }

        public bool HeeftOv { get; private set; }

        public bool HeeftAuto { get; private set; }

        public string Telefoonnummer { get; private set; }

        public DateTime Uitschrijfdatum { get;  set; }

        public string Adres { get; private set; }

        public string Woonplaats { get; private set; }

        public string Land { get; private set; }

        public string Postcode { get; private set; }

        public Geslacht Geslacht { get; private set; }

        public Gebruiker(int id, byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht)
        {
            Id = id;
            Image = image;
            Email = email;
            Wachtwoord = wachtwoord;
            Gebruikersnaam = gebruikersnaam;
            Naam = naam;
            Geboortedatum = geboortedatum;
            HeeftRijbewijs = heeftRijbewijs;
            HeeftOv = heeftOv;
            HeeftAuto = heeftAuto;
            Telefoonnummer = telefoonnummer;    
            Adres = adres;
            Woonplaats = woonplaats;
            Land = land;
            Postcode = postcode;
            Geslacht = geslacht;
        }

        public Gebruiker(byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, string adres, string woonplaats, string land, string postcode, Geslacht geslacht)
        {         
            Image = image;
            Email = email;
            Wachtwoord = wachtwoord;
            Gebruikersnaam = gebruikersnaam;
            Naam = naam;
            Geboortedatum = geboortedatum;
            HeeftRijbewijs = heeftRijbewijs;
            HeeftOv = heeftOv;
            HeeftAuto = heeftAuto;
            Telefoonnummer = telefoonnummer;
            Adres = adres;
            Woonplaats = woonplaats;
            Land = land;
            Postcode = postcode;
            Geslacht = geslacht;
        }
    }
}
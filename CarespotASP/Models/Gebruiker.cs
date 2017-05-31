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

        public byte[] Image { get;  set; }

        public string Email { get;  set; }

        public string Wachtwoord { get;  set; }

        public string Gebruikersnaam { get;  set; }

        public string Naam { get;  set; }

        public DateTime Geboortedatum { get;  set; }

        public bool HeeftRijbewijs { get;  set; }

        public bool HeeftOv { get;  set; }

        public bool HeeftAuto { get;  set; }

        public string Telefoonnummer { get;  set; }

        public DateTime Uitschrijfdatum { get; set; }

        public string Adres { get;  set; }

        public string Woonplaats { get;  set; }

        public string Land { get;  set; }

        public string Postcode { get;  set; }

        public Geslacht Geslacht { get;  set; }

        public string Barcode { get; set; }

      

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

        public Gebruiker(int id)
        {
            Id = id;
        }

        public Gebruiker(int id, byte[] image, string email, string wachtwoord, string gebruikersnaam, string naam, DateTime geboortedatum, bool heeftRijbewijs, bool heeftOv, bool heeftAuto, string telefoonnummer, DateTime uitschrijfdatum, string adres, string woonplaats, string land, string postcode, Geslacht geslacht, string barcode)
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
            Uitschrijfdatum = uitschrijfdatum;
            Adres = adres;
            Woonplaats = woonplaats;
            Land = land;
            Postcode = postcode;
            Geslacht = geslacht;
            Barcode = barcode;
        }

        public Gebruiker()
        {
            
        }
    }
}
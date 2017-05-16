using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    }
}
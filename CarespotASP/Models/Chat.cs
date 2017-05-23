using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarespotASP.Models
{
    public class Chat : IComparable<Chat>
    {
        public int Id { get; private set; }
        public Gebruiker Auteur { get; private set; }
        public Gebruiker Ontvanger { get; private set; }
        public DateTime DatumTijd { get; private set; }
        public string Bericht { get; private set; }

        public Chat()
        {
        }

        public Chat(int id, Gebruiker auteur, Gebruiker ontvanger, DateTime datumTijd, string bericht)
        {
            Id = id;
            Auteur = auteur;
            Ontvanger = ontvanger;
            DatumTijd = datumTijd;
            Bericht = bericht;
        }

        public Chat(Gebruiker auteur, Gebruiker ontvanger, DateTime datumTijd, string bericht)
        {
            Auteur = auteur;
            Ontvanger = ontvanger;
            DatumTijd = datumTijd;
            Bericht = bericht;
        }

        public int CompareTo(Chat other)
        {
            return this.DatumTijd.CompareTo(other.DatumTijd);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using CarespotASP.Enums;

namespace CarespotASP.Models
{
    public class Hulpvraag
    {
        public int Id { get; private set; }
        public string Titel { get; private set; }
        public string Omschrijving { get; private set; }
        public DateTime OpdrachtDatum { get; private set; }
        public DateTime CreateDatum { get; private set; }
        public string Locatie { get; private set; }
        public bool Urgent { get; private set; }
        public VervoerType VervoerType { get; private set; }
        public bool IsAfgerond { get; private set; }
        public List<Vaardigheid> Vaardigheden { get; set; }
        public Hulpbehoevende Hulpbehoevende { get; set; }
        public Vrijwilliger Vrijwilliger { get;  set; }

        //Constructor met id
        public Hulpvraag(int id, string titel, string omschrijving, DateTime opdrachtdatum, DateTime createdatum, string locatie, bool urgent, VervoerType vervoertype, bool isafgerond)
        {
            Id = id;
            Titel = titel;
            Omschrijving = omschrijving;
            OpdrachtDatum = opdrachtdatum;
            CreateDatum = createdatum;
            Locatie = locatie;
            Urgent = urgent;
            VervoerType = vervoertype;
            IsAfgerond = isafgerond;
        }

        //Constructor zonder id
        public Hulpvraag(string titel, string omschrijving, DateTime opdrachtdatum, DateTime createdatum, string locatie, bool urgent, VervoerType vervoertype, bool isafgerond)
        {
            Titel = titel;
            Omschrijving = omschrijving;
            OpdrachtDatum = opdrachtdatum;
            CreateDatum = createdatum;
            Locatie = locatie;
            Urgent = urgent;
            VervoerType = vervoertype;
            IsAfgerond = isafgerond;
        }
    }
}
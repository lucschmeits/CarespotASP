using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarespotASP.Models
{
    public class Beschikbaarheid
    {
        public int Id { get; set; }
        public string DagNaam { get; set; }
        public string DagDeel { get; set; }

        public Beschikbaarheid(string dagnaam, string dagdeel)
        {
            DagNaam = dagnaam;
            DagDeel = dagdeel;
        }

        public Beschikbaarheid(int id, string dagnaam, string dagdeel)
        {
            Id = id;
            DagNaam = dagnaam;
            DagDeel = dagdeel;
        }

        public Beschikbaarheid(int id)
        {
            Id = id;
        }
    }
}
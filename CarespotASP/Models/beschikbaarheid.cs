using CarespotASP.Enums;

namespace CarespotASP.Models
{
    public class Beschikbaarheid
    {
        public int Id { get; set; }
        public Dagnaam DagNaam { get; set; }
        public Dagdeel DagDeel { get; set; }

        public Beschikbaarheid(Dagnaam dagnaam, Dagdeel dagdeel)
        {
            DagNaam = dagnaam;
            DagDeel = dagdeel;
        }

        public Beschikbaarheid(int id, Dagnaam dagnaam, Dagdeel dagdeel)
        {
            Id = id;
            DagNaam = dagnaam;
            DagDeel = dagdeel;
        }
    }
}
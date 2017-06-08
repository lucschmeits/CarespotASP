namespace CarespotASP.Models
{
    public class Vaardigheid
    {
        public int Id { get; private set; }
        public string Omschrijving { get; private set; }

        public Vaardigheid(int id, string omschrijving)
        {
            Id = id;
            Omschrijving = omschrijving;
        }

        public Vaardigheid(int id)
        {
            Id = id;
        }
    }
}
namespace CarespotASP.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int AuteurId { get; set; }
        public int GebruikerId { get; set; }
        public string Omschrijving { get; set; }
        public int Beoordeling { get; set; }

        public Review()
        {
        }

        public Review(int id, int auteurId, int gebruikerId, string omschrijving, int beoordeling)
        {
            Id = id;
            AuteurId = auteurId;
            GebruikerId = gebruikerId;
            Omschrijving = omschrijving;
            Beoordeling = beoordeling;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarespotASP.Models
{
    public class Reactie
    {
        public int Id { get; set; }
        public string Bericht { get; set; }
        public DateTime Datum { get; set; }
        public int VrijwilligerId { get; set; }
        public int HulpvraagId { get; set; }

        public Reactie(string bericht, DateTime datum, int vrijwilligerId, int hulpvraagId)
        {
            Bericht = bericht;
            Datum = datum;
            VrijwilligerId = vrijwilligerId;
            HulpvraagId = hulpvraagId;
        }

        public Reactie(int id, string bericht, DateTime datum, int vrijwilligerId, int hulpvraagId)
        {
            Id = id;
            Bericht = bericht;
            Datum = datum;
            VrijwilligerId = vrijwilligerId;
            HulpvraagId = hulpvraagId;
        }
        public Reactie()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarespotASP.Models
{
    public class Chat
    {
        public int Id { get; private set; }

        public DateTime DatumTijd { get; private set; }
        public string Bericht { get; private set; }

        public Chat()
        {
        }

        public Chat(int id, DateTime datumTijd, string bericht)
        {
            Id = id;
            DatumTijd = datumTijd;
            Bericht = bericht;
        }
    }
}
using System.Collections.Generic;
using CarespotASP.Models;

namespace CarespotASP.Views.Beheerder
{
    public class BeheerderViewModel
    {
        public List<Hulpvraag> LstHulpvraag { get; set; }
        public List<Gebruiker> LstGebruiker { get; set; }
    }
}
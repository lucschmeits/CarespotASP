using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;


namespace CarespotASP.Dal.Repositorys
{
    public class HulpvraagRepository
    {
        private IHulpvraag _hulpvraagInterface;

        public HulpvraagRepository(IHulpvraag hulpvraagInterface)
        {
            _hulpvraagInterface = hulpvraagInterface;
        }
    }
}
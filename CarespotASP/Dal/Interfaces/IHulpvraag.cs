using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IHulpvraag
    {
        List<Hulpvraag> GetAll();

        Hulpvraag GetById(int id);

        void Create(Hulpvraag hulpvraag);

        void Update(int id, Hulpvraag hulpvraag);

        void Delete(int id);

        void RemoveVrijwilligerFromHulpvraag(int id);
    }
}
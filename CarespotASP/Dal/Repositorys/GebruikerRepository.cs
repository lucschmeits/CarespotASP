using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class GebruikerRepository
    {
        private IGebruiker _interface;
        public GebruikerRepository(IGebruiker i)
        {
            _interface = i;
        }

        public int Create(Gebruiker obj)
        {
            return _interface.CreateGebruiker(obj);
        }
        public List<Gebruiker> GetAll()
        {
            return _interface.GetAllGebruikers();
        }

        public Gebruiker GetById(int id)
        {
            return _interface.GetGebruikerById(id);
        }

        public void Update(Gebruiker obj)
        {
            _interface.UpdateGebruiker(obj);
        }

        public void Delete(int id)
        {
            _interface.DeleteGebruikerById(id);
        }

        public List<Gebruiker> GetUserWithType()
        {

            List<Gebruiker> returnList = new List<Gebruiker>();

            HulpbehoevendeSqlContext hbContext = new HulpbehoevendeSqlContext();
            HulpbehoevendeRepository hbRepository = new HulpbehoevendeRepository(hbContext);

            VrijwilligerSqlContext vrijwilligerContext = new VrijwilligerSqlContext();
            VrijwilligerRepository vrijwilligerRepository = new VrijwilligerRepository(vrijwilligerContext);


            BeheerderSqlContext beheerderContext = new BeheerderSqlContext();
            BeheerderRepository beheerderRepository = new BeheerderRepository(beheerderContext);

            HulpverlenerSqlContext hvContext = new HulpverlenerSqlContext();
            HulpverlenerRepository hvRepository = new HulpverlenerRepository(hvContext);


             returnList.AddRange(hbRepository.GetAllHulpbehoevenden());
            returnList.AddRange(vrijwilligerRepository.GetAllVrijwilligers());
            returnList.AddRange(beheerderRepository.GetAll());
            returnList.AddRange(hvRepository.GetAll());


            return returnList;
        }
    }
}
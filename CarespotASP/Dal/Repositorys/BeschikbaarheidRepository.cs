using System.Collections.Generic;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class BeschikbaarheidRepository
    {
        private readonly IBeschikbaarheid _interface;

        public BeschikbaarheidRepository(IBeschikbaarheid i)
        {
            _interface = i;
        }

        public List<Beschikbaarheid> GetAllBeschikbaarheid()
        {
            return _interface.GetAllBeschikbaarheid();
        }

        public Beschikbaarheid GetBeschikbaarheidById(int Id)
        {
            return _interface.GetBeschikbaarheidById(Id);
        }

        //public int CreateBeschikbaarheid(Beschikbaarheid b)
        //{
        //    return _interface.CreateBeschikbaarheid(b);
        //}
        public void DeleteBeschikbaarheid(int Id)
        {
            _interface.DeleteBeschikbaarheid(Id);
        }

        public void UpdateBeschikbaarheid(Beschikbaarheid b)
        {
            _interface.UpdateBeschikbaarheid(b);
        }

        public List<Beschikbaarheid> GetBeschikbaarheidByVrijwilligerId(int id)
        {
            return _interface.GetBeschikbaarheidByVrijwilligerId(id);
        }

        public List<Beschikbaarheid> GetBeschikbaarheidByHulpvraagId(int id)
        {
            return _interface.GetBeschikbaarheidByHulpvraagId(id);
        }

        public void Save(Beschikbaarheid beschikbaarheid, object obj)
        {
            _interface.Save(beschikbaarheid, obj);
        }

        //ReturnBeschikbaarheidByHulpvraagId
    }
}
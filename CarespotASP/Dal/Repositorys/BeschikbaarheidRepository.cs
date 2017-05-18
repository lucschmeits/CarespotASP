using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Models;
using CarespotASP.Dal.Interfaces;

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
        public int CreateBeschikbaarheid(Beschikbaarheid b)
        {
            return _interface.CreateBeschikbaarheid(b);
        }
        public void DeleteBeschikbaarheid(int Id)
        {
            _interface.DeleteBeschikbaarheid(Id);
        }

        public void UpdateBeschikbaarheid(Beschikbaarheid b)
        {
            _interface.UpdateBeschikbaarheid(b);
        }
    }
}
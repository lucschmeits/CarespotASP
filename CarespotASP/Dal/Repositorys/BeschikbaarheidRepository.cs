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

        public List<Beschikbaarheid> getAllBeschikbaarheid()
        {
            return _interface.getAllBeschikbaarheid();
        }
        public Beschikbaarheid getBeschikbaarheidById(int Id)
        {
            return _interface.getBeschikbaarheidById(Id);
        }
        public void CreateBeschikbaarheid(Beschikbaarheid b)
        {
            _interface.CreateBeschikbaarheid(b);
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
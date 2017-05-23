using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class VaardigheidRepository
    {
        private IVaardigheid _interface;
        public VaardigheidRepository(IVaardigheid i)
        {
            _interface = i;
        }

        public int Create(Vaardigheid obj)
        {
            return _interface.CreateVaardigheid(obj);
        }
        public List<Vaardigheid> GetAll()
        {
            return _interface.GetAllVaardigheden();
        }

        public Vaardigheid GetById(int id)
        {
            return _interface.GetVaardigheidById(id);
        }

        public void Update(Vaardigheid obj)
        {
            _interface.UpdateVaardigheid(obj);
        }

        public void Delete(int id)
        {
            _interface.DeleteVaardigheidById(id);
        }

        public List<Vaardigheid> GetVaardigheidByVrijwilligerId(int id)
        {
            return _interface.GetVaardigheidByVrijwilligerId(id);
        }

        public List<Vaardigheid> GetVaardigheidByHulpvraagId(int id)
        {
            return _interface.GetVaardigheidByHulpvraagId(id);
        }
    }
}
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;
using System.Collections.Generic;

namespace CarespotASP.Dal.Repositorys
{
    public class BeheerderRepository
    {
        private IBeheerder _interface;

        public BeheerderRepository(IBeheerder i)
        {
            _interface = i;
        }

        public void Create(int id)
        {
            _interface.CreateBeheerder(id);
        }

        public List<Beheerder> GetAll()
        {
            return _interface.GetAllBeheerders();
        }

        public Beheerder GetById(int id)
        {
            return _interface.GetBeheerderById(id);
        }

        public void Delete(int id)
        {
            _interface.DeleteBeheerderById(id);
        }
    }
}
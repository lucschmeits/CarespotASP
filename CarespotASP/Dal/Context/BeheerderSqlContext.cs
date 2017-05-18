using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class BeheerderSqlContext :IBeheerder
    {
        public List<Beheerder> GetAllBeheerders()
        {
            throw new NotImplementedException();
        }

        public Beheerder GetBeheerderById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateBeheerder()
        {
            throw new NotImplementedException();
        }

        public void UpdateBeheerder()
        {
            throw new NotImplementedException();
        }

        public void DeleteBeheerderById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
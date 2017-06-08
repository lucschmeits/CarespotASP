using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestBeheerder
    {
        //Haal alles op met gebruiker erin
        [TestMethod]
        public void Retrieveall()
        {
            BeheerderSqlContext bsc = new BeheerderSqlContext();
            BeheerderRepository br = new BeheerderRepository(bsc);

            List<Beheerder> beheerderLijst = br.GetAll();

            Assert.IsTrue(beheerderLijst.Count > 1);
        }

        //haal op met gebruiker erin
        [TestMethod]
        public void Retrieve()
        {
            BeheerderSqlContext bsc = new BeheerderSqlContext();
            BeheerderRepository br = new BeheerderRepository(bsc);

            Beheerder b = br.GetById(4);

            Assert.IsTrue(b.Id == 4);
        }

        //create met gebruiker id
        [TestMethod]
        public void Create()
        {
            BeheerderSqlContext bsc = new BeheerderSqlContext();
            BeheerderRepository br = new BeheerderRepository(bsc);

            br.Create(1);
        }

        //Delete met id
        [TestMethod]
        public void Delete()
        {
            BeheerderSqlContext bsc = new BeheerderSqlContext();
            BeheerderRepository br = new BeheerderRepository(bsc);

            br.Delete(1);
        }
    }
}
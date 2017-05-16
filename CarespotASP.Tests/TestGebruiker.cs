using System;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestGebruiker
    {
        [TestMethod]
        public void GetAll()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            var Lijst = gr.GetAll();
            Assert.IsTrue(Lijst.Count > 0);
        }


        [TestMethod]
        public void GetById()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);
            int id = 1;
            var User = gr.GetById(id);
            Assert.AreEqual(id, User.Id);
        }


        [TestMethod]
        public void Create()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            var User = gr.GetById(1);

            int id = gr.Create(User);
            var nieuweUser = gr.GetById(id);

            Assert.AreEqual(id, nieuweUser.Id);

        }

        

    }
}

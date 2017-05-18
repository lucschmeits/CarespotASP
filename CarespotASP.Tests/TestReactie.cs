using System;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestReactie
    {
        [TestMethod]
        public void Create()
        {
            ReactieSqlContext rsc = new ReactieSqlContext();
            ReactieRepository rr = new ReactieRepository(rsc);

            var reactie = new Reactie("test", DateTime.Now, 1, 1);

            int id = rr.CreateReactie(reactie);
            var nieuweReactie = rr.GetReactieById(id);

            Assert.AreEqual(id, nieuweReactie.Id);
        }

        [TestMethod]
        public void GetAll()
        {
            ReactieSqlContext rsc = new ReactieSqlContext();
            ReactieRepository rr = new ReactieRepository(rsc);

            var Lijst = rr.GetAllReacties();
            Assert.IsTrue(Lijst.Count == 0);
        }

        [TestMethod]
        public void GetById()
        {
            ReactieSqlContext rsc = new ReactieSqlContext();
            ReactieRepository rr = new ReactieRepository(rsc);
            int id = 1;
            var reactie = rr.GetReactieById(id);
            Assert.AreEqual(id, reactie.Id);
        }

        [TestMethod]
        public void Delete()
        {
            ReactieSqlContext rsc = new ReactieSqlContext();
            ReactieRepository rr = new ReactieRepository(rsc);

            int oudeCount = rr.GetAllReacties().Count;
            rr.DeleteReactieById(1);
            int nieuweCount = rr.GetAllReacties().Count;
            Assert.AreEqual(oudeCount, (nieuweCount + 1));
        }

    }
}

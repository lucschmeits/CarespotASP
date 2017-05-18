using System;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestBeschikbaarheid
    {
        [TestMethod]
        public void Create()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            var beschikbaarheid = new Beschikbaarheid("Maandag", "Avond");

            int id = br.CreateBeschikbaarheid(beschikbaarheid);
            var nieuweBeschikbaarheid = br.GetBeschikbaarheidById(id);

            Assert.AreEqual(id, nieuweBeschikbaarheid.Id);
        }

        [TestMethod]
        public void GetAll()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            var Lijst = br.GetAllBeschikbaarheid();
            Assert.IsTrue(Lijst.Count > 0);
        }

        [TestMethod]
        public void GetById()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);
            int id = 1;
            var beschikbaarheid = br.GetBeschikbaarheidById(id);
            Assert.AreEqual(id, beschikbaarheid.Id);
        }

        [TestMethod]
        public void Delete()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            int oudeCount = br.GetAllBeschikbaarheid().Count;
            br.DeleteBeschikbaarheid(2);
            int nieuweCount = br.GetAllBeschikbaarheid().Count;
            Assert.AreEqual(oudeCount, (nieuweCount + 1));
        }

        [TestMethod]
        public void Update()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            Beschikbaarheid b = br.GetBeschikbaarheidById(3);
            b.DagNaam = "Zondag";
            br.UpdateBeschikbaarheid(b);
            Assert.AreEqual("Zondag", b.DagNaam);
        }
    }
}

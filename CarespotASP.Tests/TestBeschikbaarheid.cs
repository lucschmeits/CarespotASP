using System.Collections.Generic;
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
        public void Save()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
            VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

            Vrijwilliger vrijw = vr.GetVrijwilligerById(4);

            HulpvraagSqlContext hsc = new HulpvraagSqlContext();
            HulpvraagRepository hr = new HulpvraagRepository(hsc);

            Hulpvraag hulpvrg = hr.GetById(5);

            int id = 19;
            Beschikbaarheid beschikbaarheid = br.GetBeschikbaarheidById(id);

            br.Save(beschikbaarheid, hulpvrg);
        }

        [TestMethod]
        public void GetAll()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            List<Beschikbaarheid> Lijst = br.GetAllBeschikbaarheid();

            Assert.IsTrue(Lijst.Count > 0);
        }

        [TestMethod]
        public void GetById()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            int id = 17;
            Beschikbaarheid beschikbaarheid = br.GetBeschikbaarheidById(id);

            Assert.AreEqual(id, beschikbaarheid.Id);
        }

        [TestMethod]
        public void GetByVrijwilligerId()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
            VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

            Vrijwilliger vrijw = vr.GetVrijwilligerById(4);

            List<Beschikbaarheid> LstBsch = br.GetBeschikbaarheidByVrijwilligerId(vrijw.Id);

            Assert.IsTrue(LstBsch.Count > 0);
        }

        [TestMethod]
        public void GetByHulpvraagId()
        {
            BeschikbaarheidSqlContext bsc = new BeschikbaarheidSqlContext();
            BeschikbaarheidRepository br = new BeschikbaarheidRepository(bsc);

            HulpvraagSqlContext hsc = new HulpvraagSqlContext();
            HulpvraagRepository hr = new HulpvraagRepository(hsc);

            Hulpvraag hulpvrg = hr.GetById(5);

            List<Beschikbaarheid> LstBsch = br.GetBeschikbaarheidByHulpvraagId(hulpvrg.Id);

            Assert.IsTrue(LstBsch.Count > 0);
        }
    }
}
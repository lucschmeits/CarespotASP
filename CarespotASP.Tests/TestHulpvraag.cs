using System;
using System.Collections.Generic;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestHulpvraag
    {
        [TestMethod]
        public void GetAll()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            var Lijst = hvr.GetAll();
        }

        [TestMethod]
        public void GetById()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            Hulpvraag hulpvraag = hvr.GetById(1);
            Assert.AreEqual(1,hulpvraag.Vaardigheden[0].Omschrijving);
        }

        [TestMethod]
        public void Create()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            Hulpvraag hulpvraag = hvr.GetById(1);


            VaardigheidSqlContext vsc = new VaardigheidSqlContext();
            VaardigheidRepository vr = new VaardigheidRepository(vsc);
            hulpvraag.Vaardigheden = vr.GetAll();

            hvr.Create(hulpvraag);
        }

        [TestMethod]
        public void Delete()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            hvr.Delete(3);

        }

        [TestMethod]
        public void Update()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            Hulpvraag hulpvraag = hvr.GetById(1);
            
            hvr.Update(1,hulpvraag);

        }


        [TestMethod]
        public void GetHulpvragenByHulpbehoevendeId()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            List<Hulpvraag> lijst = new List<Hulpvraag>();
            lijst = hvr.GetHulpvragenByHulpbehoevendeId(4);
            Assert.AreEqual(5,lijst.Count);

        }

        [TestMethod]
        public void GetHulpvragenByVrijwilligerId()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            List<Hulpvraag> lijst =  hvr.GetHulpvragenByVrijwilligerId(4);
          

        }


    }
}
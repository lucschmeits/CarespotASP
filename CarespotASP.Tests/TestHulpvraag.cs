using System;
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
            Assert.IsTrue(Lijst.Count == 0);
        }

        [TestMethod]
        public void GetById()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            var Hulpvraag = hvr.GetById(1);

           
         
        }

        [TestMethod]
        public void Create()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            DateTime localDate = DateTime.Now;

            Hulpvraag hv = new Hulpvraag(1,"Test","omschv",localDate,localDate,"rooy",true,VervoerType.Auto ,false);



      //      hv.Hulpbehoevende = new Hulpbehoevende();
      //      hv.Hulpbehoevende.Id = 0;

            hvr.Create(hv);

        }

        [TestMethod]
        public void Delete()
        {
           
        }

        [TestMethod]
        public void Update()
        {
          


        }


    }
}
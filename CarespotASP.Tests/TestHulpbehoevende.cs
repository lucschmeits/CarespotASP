using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestHulpbehoevende
    {
        //
        [TestMethod]
        public void GetHulpbehoevendeById()
        {
            HulpbehoevendeSqlContext context = new HulpbehoevendeSqlContext();
            HulpbehoevendeRepository hr = new HulpbehoevendeRepository(context);

            Hulpbehoevende hulpje = hr.GetHulpbehoevendeById(4);

            Assert.AreEqual(1,hulpje.Hulpverlener.Id);
        }

        [TestMethod]
        public void CreateHulpbehoevende()
        {
            HulpbehoevendeSqlContext context = new HulpbehoevendeSqlContext();
            HulpbehoevendeRepository hr = new HulpbehoevendeRepository(context);

        }

        [TestMethod]
        public void RetrieveAll()
        {
            HulpbehoevendeSqlContext context = new HulpbehoevendeSqlContext();
            HulpbehoevendeRepository hr = new HulpbehoevendeRepository(context);
         List<Hulpbehoevende> lijst =   hr.GetAllHulpbehoevenden();




        }


    }
}
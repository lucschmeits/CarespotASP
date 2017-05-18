using System;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestHulpverlener
    {
        [TestMethod]
        public void TestAllHulpverleners()
        {
            var sql = new HulpverlenerSqlContext();
            var repo = new HulpverlenerRepository(sql);

            var hulpverlenerList = repo.GetAll();

            Assert.IsTrue(hulpverlenerList[0].Id == 1);
        }

        [TestMethod]
        public void TestHulpverlenerId()
        {
            var sql = new HulpverlenerSqlContext();
            var repo = new HulpverlenerRepository(sql);

            var hulpverlener = repo.GetById(1);

            Assert.AreEqual("snekmel", hulpverlener.Gebruikersnaam);
        }
    }
}
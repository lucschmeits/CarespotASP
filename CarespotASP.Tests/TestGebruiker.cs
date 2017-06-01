using System;
using System.Collections.Generic;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestGebruiker
    {

        [TestMethod]
        public void AuthTest()
        {

            Gebruiker g = AuthRepository.CheckAuth("larslemkens@gmail.com", "test");

            Gebruiker g1 = AuthRepository.CheckAuth("larslemkens@gmail.com", "t");
            Assert.IsTrue(g != null);
            Assert.IsTrue(g1 == null);
        }


        [TestMethod]
        public void Barcodetest()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            var Lijst = gr.GetAll();
            Assert.IsTrue(Lijst[0].Barcode == null);
            Assert.IsTrue(Lijst[1].Barcode == "12345");
        }



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

        [TestMethod]
        public void Delete()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            int oudeCount = gr.GetAll().Count;

           // gr.Delete(3);

            int nieuweCount = gr.GetAll().Count;

            Assert.AreEqual(oudeCount,(nieuweCount - 1));
        }

        [TestMethod]
        public void Update()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            Gebruiker g = gr.GetById(1);
            g.Uitschrijfdatum = DateTime.Now;
            g.Naam = g.Naam + "aangepast";
            gr.Update(g);

            
        }

        [TestMethod]
        public void RetrieveWithType()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);
            
        List<Gebruiker> list = gr.GetUserWithType();

       Assert.IsTrue(list.Count > 5);

        }

        [TestMethod]

        public void GetUserTypesByUserIdtest()
        {
            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            List<Gebruiker> glijst = gr.GetUserTypesByUserId(4);

            Assert.IsTrue(glijst.Count > 0);
        }





    }
}
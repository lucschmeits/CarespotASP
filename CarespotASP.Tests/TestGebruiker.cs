﻿using System;
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
<<<<<<< HEAD

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
    
        

=======
>>>>>>> 43c423be63b38bd311efaab2047769ea42b70422
    }
}
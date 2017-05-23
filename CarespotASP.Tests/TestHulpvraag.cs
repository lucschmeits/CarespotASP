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
        }

        [TestMethod]
        public void GetById()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            Hulpvraag hulpvraag = hvr.GetById(1);
            Assert.IsNotNull(hulpvraag);
        }

        [TestMethod]
        public void Create()
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            Hulpvraag hulpvraag = hvr.GetById(1); 

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


    }
}
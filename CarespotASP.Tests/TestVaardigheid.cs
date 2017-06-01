using System;
using System.Collections.Generic;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestVaardigheid
    {
        [TestMethod]
        public void TestAll()
        {
            VaardigheidSqlContext vsc = new VaardigheidSqlContext();
            VaardigheidRepository vr = new VaardigheidRepository(vsc);

            Assert.IsTrue(vr.GetAll().Count > 0);
        }




        [TestMethod]
        public void TestVaardigheid_vrijwilliger()
        {

            VaardigheidSqlContext vsc = new VaardigheidSqlContext();
            VaardigheidRepository vr = new VaardigheidRepository(vsc);

            Assert.IsTrue(vr.GetVaardigheidByVrijwilligerId(4).Count == 2);
            Assert.IsTrue(vr.GetVaardigheidByVrijwilligerId(4)[0].Omschrijving == "Computerkennis");


        }



        [TestMethod]
        public void TestVaardigheid_hulpvraag()
        {

            VaardigheidSqlContext vsc = new VaardigheidSqlContext();
            VaardigheidRepository vr = new VaardigheidRepository(vsc);


            List<Vaardigheid> vaardigheden = vr.GetVaardigheidByHulpvraagId(1);
            Assert.AreEqual("Computer",vaardigheden[0].Omschrijving);

        }


    }
}

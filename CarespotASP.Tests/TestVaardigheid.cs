using System;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
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

         
            // KAN IK NOT NIET TESTEN, GEEN HULPVRAAG

        }
    }
}

using System;
using System.Collections.Generic;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestVrijwilliger
    {
        [TestMethod]
        public void Create()
        {
            VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
            VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

            vr.Create(4, "/VOG/Test");

        }
        [TestMethod]
        public void Retrieve()
        {
            VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
            VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

            Vrijwilliger v = vr.GetVrijwilligerById(4);

            Assert.IsTrue(v.Id == 4);
            Assert.IsTrue(v.Telefoonnummer == "0634810013");
            Assert.IsTrue(v.VOG == "/VOG/Test");

        }
        [TestMethod]
        public void RetrievAll()
        {
            VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
            VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

            List<Vrijwilliger> lijst = vr.GetAllVrijwilligers();

            Assert.IsTrue(lijst[0].Id == 4);
            Assert.IsTrue(lijst[0].Telefoonnummer == "0634810013");
            Assert.IsTrue(lijst[0].VOG == "/VOG/Test");

        }
        [TestMethod]
        public void Update()
        {
            VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
            VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

            vr.UpdateVrijwilliger(4,"Path",true);
        }
        [TestMethod]
        public void Delete()
        {

            VrijwilligerSqlContext vsc = new VrijwilligerSqlContext();
            VrijwilligerRepository vr = new VrijwilligerRepository(vsc);

            vr.DeleteVrijwillige(4);
        }
    }
}

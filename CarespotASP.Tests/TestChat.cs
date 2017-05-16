using System;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestChat
    {
        [TestMethod]
        public void TestCreateChat()
        {
            var sql = new ChatSqlContext();
            var repo = new ChatRepository(sql);
            var g1 = new Gebruiker(1);
            var g2 = new Gebruiker(2);

            var chat = new Chat(g1, g2, DateTime.Now, "Hallo jongens");
            repo.Create(chat);
        }

        [TestMethod]
        public void TestGetChat()
        {
        }
    }
}
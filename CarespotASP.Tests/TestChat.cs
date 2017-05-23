using System;
using System.Collections.Generic;
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
            var gsql = new GebruikerSqlContext();
            var grepo = new GebruikerRepository(gsql);
            var g1 = grepo.GetById(1);
            var g2 = grepo.GetById(4);

            var chat = new Chat(g1, g2, DateTime.Now, "Hallo jongens");
            repo.Create(chat);
        }

        [TestMethod]
        public void TestGetChat()
        {
            var sql = new ChatSqlContext();
            var repo = new ChatRepository(sql);

            repo.GetById(2);

            Assert.AreEqual(1, repo.GetById(2).Auteur.Id);
        }

        [TestMethod]
        public void TestGetAllChat()
        {
            var sql = new ChatSqlContext();
            var repo = new ChatRepository(sql);

            repo.GetAll();

            Assert.AreEqual(1, repo.GetAll()[0].Auteur.Id);
        }

        [TestMethod]
        public void TestChatByGebruikerId()
        {

            var sql = new ChatSqlContext();
            var repo = new ChatRepository(sql);

            List<Chat> Chatberichten = repo.GetChatByUsers(4, 1);

            Assert.IsTrue(Chatberichten.Count == 4);
            Assert.IsTrue(Chatberichten[0].Id == 2);
            Assert.IsTrue(Chatberichten[3].Id == 5);

        }
    }
}
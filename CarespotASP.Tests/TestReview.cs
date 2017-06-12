using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarespotASP.Tests
{
    [TestClass]
    public class TestReview
    {
        [TestMethod]
        public void TestCreateReview()
        {
            var sql = new ReviewSqlContext();
            var repo = new ReviewRepository(sql);

            var review = new Review(1, 4, "Tralala", 8);
            int i = repo.CreateReview(review);

            Assert.AreEqual(6, i);
        }

        [TestMethod]
        public void TestGetReviewById()
        {
            var sql = new ReviewSqlContext();
            var repo = new ReviewRepository(sql);

            Assert.AreEqual(1, repo.GetReviewById(2).AuteurId);
        }

        [TestMethod]
        public void TestGetAllReview()
        {
            var sql = new ReviewSqlContext();
            var repo = new ReviewRepository(sql);

            var LstRvw = repo.GetAllReviews();

            Assert.AreEqual(1, LstRvw[0].AuteurId);
        }


        [TestMethod]
        public void CanReview()
        {
            var sql = new ReviewSqlContext();
            var repo = new ReviewRepository(sql);

            bool result = repo.CanReview(1045, 1042);



        }
    }
}
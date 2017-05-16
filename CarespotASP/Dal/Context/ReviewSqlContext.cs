using System;
using System.Collections.Generic;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Context
{
    public class ReviewSqlContext : IReview
    {
        public List<Review> GetAllReviews()
        {
            throw new NotImplementedException();
        }

        public Review GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public int CreateReview(Review review)
        {
            throw new NotImplementedException();
        }

        public void UpdateReview(Review review)
        {
            throw new NotImplementedException();
        }

        public void DeleteReviewById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
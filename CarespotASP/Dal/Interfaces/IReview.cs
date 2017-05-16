using System.Collections.Generic;
using CarespotASP.Models;

namespace CarespotASP.Dal.Interfaces
{
    public interface IReview
    {
        List<Review> GetAllReviews();

        Review GetReviewById(int id);

        int CreateReview(Review review);

        void UpdateReview(Review review);

        void DeleteReviewById(int id);
    }
}
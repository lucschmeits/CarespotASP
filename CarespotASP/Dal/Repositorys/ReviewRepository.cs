using System.Collections.Generic;
using System.Linq;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;

namespace CarespotASP.Dal.Repositorys
{
    public class ReviewRepository
    {
        private readonly IReview _reviewInterface;

        public ReviewRepository(IReview reviewInterface)
        {
            _reviewInterface = reviewInterface;
        }

        public List<Review> GetAllReviews()
        {
            return _reviewInterface.GetAllReviews();
        }

        public Review GetReviewById(int id)
        {
            return _reviewInterface.GetReviewById(id);
        }

        public int CreateReview(Review review)
        {
            return _reviewInterface.CreateReview(review);
        }

        public void UpdateReview(Review review)
        {
            _reviewInterface.UpdateReview(review);
        }

        public void DeleteReviewById(int id)
        {
            _reviewInterface.DeleteReviewById(id);
        }

        public List<Review> GetReviewByVrijwilligerId(int id)
        {
            return this.GetAllReviews().Where(r => r.GebruikerId == id).ToList();

        }

        public List<Review> GetReviewByHulpbehoevendeId(int id)
        {
            return this.GetAllReviews().Where(r => r.AuteurId == id).ToList();
        }

    }

}
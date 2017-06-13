using CarespotASP.Dal.Context;
using CarespotASP.Dal.Interfaces;
using CarespotASP.Models;
using System.Collections.Generic;
using System.Linq;

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

        public bool CanReview(int hulpbehoevendeId, int vrijwilligerId)
        {
            HulpvraagSqlContext hsc = new HulpvraagSqlContext();
            HulpvraagRepository hr = new HulpvraagRepository(hsc);

            List<Hulpvraag> hulpvragen = hr.GetHulpvragenByHulpbehoevendeId(hulpbehoevendeId);
            List<Review> reviews = this.GetReviewByHulpbehoevendeId(hulpbehoevendeId);

            bool returnValue = false;
            foreach (Hulpvraag hv in hulpvragen)
            {
                //Hulpbehoevende zit gekoppeld aan vrijwilliger in hulpvraag
                if (hv.Vrijwilliger.Id == vrijwilligerId)
                {
                    returnValue = true;

                    foreach (Review r in reviews)
                    {
                        //Check of review al bestaat
                        if (r.GebruikerId == vrijwilligerId)
                        {
                            returnValue = false;
                        }
                    }
                }
            }
            return returnValue;
        }
    }
}
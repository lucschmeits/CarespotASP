using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review/New
        [HttpPost]
        public ActionResult New(FormCollection form)
        {

            ReviewSqlContext sql = new ReviewSqlContext();
            ReviewRepository repo = new ReviewRepository(sql);



            string omschrijving = form["omschrijving"];
            int beoordeling = Convert.ToInt32(form["beoordeling"]);
            int vrijwilligerId =Convert.ToInt32(form["vrijwilligerId"]);
            int hulpbehoevendeId = Convert.ToInt32(form["hulpbehoevendeId"]);

            Review newReview = new Review(hulpbehoevendeId, vrijwilligerId, omschrijving, beoordeling);
            repo.CreateReview(newReview);

          
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
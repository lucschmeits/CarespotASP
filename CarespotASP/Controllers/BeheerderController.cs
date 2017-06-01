using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Views.Beheerder;

namespace CarespotASP.Controllers
{
    public class BeheerderController : Controller
    {
        // GET: Beheerder
        public ActionResult Index()
        {
            BeheerderViewModel model = new BeheerderViewModel();

            HulpvraagSqlContext hsc = new HulpvraagSqlContext();
            HulpvraagRepository hr = new HulpvraagRepository(hsc);

            GebruikerSqlContext gsc = new GebruikerSqlContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            model.LstGebruiker = gr.GetAll();
            model.LstHulpvraag = hr.GetAll();

            return View(model);
        }

        // GET: Beheerder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beheerder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beheerder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beheerder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beheerder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Beheerder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beheerder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
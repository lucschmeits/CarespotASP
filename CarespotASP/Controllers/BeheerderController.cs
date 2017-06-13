using System;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Models;
using CarespotASP.Views.Beheerder;

namespace CarespotASP.Controllers
{
    public class BeheerderController : Controller
    {
        // GET: Beheerder
        public ActionResult Index()
        {
            try
            {
                BeheerderViewModel model = new BeheerderViewModel();

                HulpvraagSqlContext hsc = new HulpvraagSqlContext();
                HulpvraagRepository hr = new HulpvraagRepository(hsc);

                GebruikerSqlContext gsc = new GebruikerSqlContext();
                GebruikerRepository gr = new GebruikerRepository(gsc);

                model.LstGebruiker = gr.GetUserWithType();
                model.LstHulpvraag = hr.GetAll();

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Beheerder/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                HulpvraagSqlContext hsc = new HulpvraagSqlContext();
                HulpvraagRepository hr = new HulpvraagRepository(hsc);
                Hulpvraag hulpvrg = hr.GetById(id);
                return View(hulpvrg);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
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
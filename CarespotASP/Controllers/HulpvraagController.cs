using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarespotASP.Dal.Context;
using CarespotASP.Dal.Repositorys;
using CarespotASP.Enums;
using CarespotASP.Models;

namespace CarespotASP.Controllers
{
    public class HulpvraagController : Controller
    {
        // GET: Hulpvraag
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOpdracht(FormCollection form)
        {

            //Vervoerstype parsen
            VervoerType vervoerstype = (VervoerType) Enum.Parse(typeof(VervoerType), form["vervoertype"]);

            //Urgentie controleren
            bool urgent = false;

            if (form["urgent"] == "urgent")
            {
                urgent = true;
            }


            //Hulpbehoevende ophalen/toevoegen
            HulpbehoevendeSqlContext hbsc = new HulpbehoevendeSqlContext();
            HulpbehoevendeRepository hbr = new HulpbehoevendeRepository(hbsc);

            Hulpbehoevende hulpbehoevende = hbr.GetHulpbehoevendeById(1027); //Hier straks de ingelogde gebruiker 

            var hulpvraag = new Hulpvraag(
                form["titel"],
                form["beschrijving"],
                DateTime.Parse(form["opdrachtdatum"]),
                DateTime.Now,
                form["locatie"],
                urgent,
                vervoerstype,
                false,
                hulpbehoevende
            );


            if (form["vaardigheden[]"] != null)
            {
                string s = form["vaardigheden[]"];

                if (s != null)
                {
                    int[] vaardighedenids = Array.ConvertAll(s.Split(','), int.Parse);

                    hulpvraag.Vaardigheden = new List<Vaardigheid>();

                    foreach (int id in vaardighedenids)
                    {
                        var vaardigheid = new Vaardigheid(id);
                        hulpvraag.Vaardigheden.Add(vaardigheid);
                    }
                }           
            }

            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            hvr.Create(hulpvraag);

           return RedirectToAction("Index", "Hulpbehoevende");
        }


        [HttpGet]
        public ActionResult DeleteHulpvraag(int id)
        {
            HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
            HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

            hvr.Delete(id);

            return RedirectToAction("Index", "Hulpbehoevende");
        }
    }
}
﻿using System;
using System.Collections.Generic;
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

        [HttpPost]
        public ActionResult CreateOpdracht(FormCollection form)
        {
            try
            {
                //Vervoerstype parsen
                VervoerType vervoerstype = (VervoerType) Enum.Parse(typeof(VervoerType), form["vervoertype"]);

                //Urgentie controleren
                bool urgent = false;

                if (form["urgent"] == "urgent")
                {
                    urgent = true;
                }


                //Haal de ingelogde gebruiker op
                var hulpbehoevende = (Hulpbehoevende) Session["LoggedInUser"];

                ////Hulpbehoevende ophalen/toevoegen
                //HulpbehoevendeSqlContext hbsc = new HulpbehoevendeSqlContext();
                //HulpbehoevendeRepository hbr = new HulpbehoevendeRepository(hbsc);

                //Hulpbehoevende hulpbehoevende = hbr.GetHulpbehoevendeById(gebruiker.Id);

                Hulpvraag hulpvraag = new Hulpvraag(
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
                            Vaardigheid vaardigheid = new Vaardigheid(id);
                            hulpvraag.Vaardigheden.Add(vaardigheid);
                        }
                    }
                }

                HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
                HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

                hvr.Create(hulpvraag);

                return RedirectToAction("Index", "Hulpbehoevende");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult DeleteHulpvraag(int id)
        {
            try
            {
                HulpvraagSqlContext hvsc = new HulpvraagSqlContext();
                HulpvraagRepository hvr = new HulpvraagRepository(hvsc);

                hvr.Delete(id);

                return RedirectToAction("Index", "Hulpbehoevende");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarespotASP.Controllers
{
    public class BeoordelingController : Controller
    {
        // GET: Beoordeling
        public ActionResult Index()
        {
            return View("NieuwBeoordeling");
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Project()
        {
            return View();
        }
        public ActionResult Reference()
        {
            return View();
        }
    }
}
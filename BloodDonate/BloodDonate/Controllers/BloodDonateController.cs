using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodDonate.Controllers
{
    public class BloodDonateController : Controller
    {
        // GET: BloodDonate
        public ActionResult Index()
        {
            return View();
        }
    }
}
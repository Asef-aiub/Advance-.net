using Lab_Task_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_Task_2.Controllers
{
    public class RegController : Controller
    {
        // GET: Reg
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(Student student)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success", "Reg");
            }
            return View(student);
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}
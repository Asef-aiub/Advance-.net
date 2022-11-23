using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.DB;

namespace zeroHunger.Controllers
{
    public class AssignController : Controller
    {
        zero_hungerEntities db = new zero_hungerEntities();

        // GET: Assign
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult createAssign()
        {
            var db = new zero_hungerEntities();

            var empList1 = db.Employees.ToList();

            ViewBag.EmpList1 = new SelectList(empList1, "EmId", "EmpName");

            var empList2 = db.Requests.ToList();

            ViewBag.EmpList2 = new SelectList(empList2, "RequestId", "RequestId");
            return View();
        }
        [HttpPost]
        public ActionResult CreateAssign(EmployeeAssign ea)
        {
            
           var db = new zero_hungerEntities();
            ea.Status = "Pending";
            db.EmployeeAssigns.Add(ea);

            db.SaveChanges();
            return RedirectToAction("status");
            
        }
        public ActionResult status()
        {
            return View(db.EmployeeAssigns.ToList());
        }
        [HttpGet]
        public ActionResult Done(int id)
        {
            var db = new zero_hungerEntities();
            var ext = (
                from pr in db.EmployeeAssigns
                where pr.Id == id
                select pr).SingleOrDefault();
            ext.Status = "Completed";
            db.SaveChanges();
            return RedirectToAction("status");
        }

      




     

    }
}
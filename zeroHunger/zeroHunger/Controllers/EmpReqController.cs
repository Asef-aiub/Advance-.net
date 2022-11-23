using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zeroHunger.DB;

namespace zeroHunger.Controllers
{
    public class EmpReqController : Controller
    {
        zero_hungerEntities db = new zero_hungerEntities();
        // GET: EmpReq
        public ActionResult Index()
        { 
            return View();
        }

        [HttpGet]
        public ActionResult employee()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            var db = new zero_hungerEntities();
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("employee");
        }
        [HttpGet]
        public ActionResult DeleteEmp(int id)
        {
  
            var db = new zero_hungerEntities();
            var ext1 = (
                from em in db.Employees
                where em.EmId == id
                select em).SingleOrDefault();

            var ext2 = (
                from em in db.EmployeeAssigns
                where em.EmployeeId == id
                select em).SingleOrDefault();

            if (ext1.EmId == ext2.EmployeeId)
            {
                db.EmployeeAssigns.Remove(ext2);
                db.SaveChanges();
                db.Employees.Remove(ext1);
                db.SaveChanges();
                return RedirectToAction("employee");
            }
            else
            {
                db.Employees.Remove(ext1);
                db.SaveChanges();
                return RedirectToAction("employee");
            }
        }
        [HttpGet]
        public ActionResult request()
        {
            return View(db.Requests.ToList());
        }
        public ActionResult CreateReq()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateReq(Request r)
        {
            var db = new zero_hungerEntities();
            db.Requests.Add(r);
            db.SaveChanges();
            return RedirectToAction("request");
        }
        [HttpGet]
        public ActionResult EditReq(int id)
        {
            var db = new zero_hungerEntities();
            var ext = (
                from pr in db.Requests
                where pr.RequestId == id
                select pr).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult EditReq(Request r)
        {
            var db = new zero_hungerEntities();
            var ext = (from pr in db.Requests
                       where pr.RequestId == r.RequestId
                       select pr).SingleOrDefault();
            ext.RestName = r.RestName;
            ext.FoodName = r.FoodName;
            ext.Qty = r.Qty;
            ext.PreserveTime = r.PreserveTime;
            db.SaveChanges();
            return RedirectToAction("request");

        }
       


    }
}
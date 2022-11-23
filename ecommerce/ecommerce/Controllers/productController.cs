using ecommerce.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecommerce.Controllers
{
    public class productController : Controller
    {
        ecommerceEntities1 db = new ecommerceEntities1();

        // GET: product
        [HttpGet]
        public ActionResult products()
        {
                return View(db.products.ToList());
        }

        [HttpPost]
        public ActionResult products(int[] products)
        {
            foreach(var id in products)
            {
                db.products.Add(new product()
                {
                    id = id
                });
            }
            db.SaveChanges();
            return RedirectToAction("products");
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(product p)
        {
            var db = new ecommerceEntities1();
            db.products.Add(p);
            db.SaveChanges();
            return RedirectToAction("products");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ecommerceEntities1();
            var ext = (
                from pr in db.products
                where pr.id == id
                select pr).SingleOrDefault();
                return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(product p)
        {
            var db = new ecommerceEntities1();
            var ext = (from pr in db.products
                       where pr.id == p.id
                       select pr).SingleOrDefault();
            ext.name = p.name;
            ext.price = p.price;
            ext.qty = p.qty;
            db.SaveChanges();
             return RedirectToAction("products");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new ecommerceEntities1();
            var ext = (
                from pr in db.products
                where pr.id == id
                select pr).SingleOrDefault();
            db.products.Remove(ext);
            db.SaveChanges();
            return RedirectToAction("products");
        }
       


    }
}
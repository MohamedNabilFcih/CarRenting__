using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car_Renting.Models;
using WebApplication1.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Car_Renting.Controllers
{
   

    public class CarsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.category);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.categoryid = new SelectList(db.categories, "id", "categoryname");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cars cars, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = System.IO.Path.Combine(Server.MapPath("~/upload"), upload.FileName);
                upload.SaveAs(path);
                cars.carimg = upload.FileName;
                cars.UserId = User.Identity.GetUserId();
                db.Cars.Add(cars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryid = new SelectList(db.categories, "id", "categoryname", cars.categoryid);
            return View(cars);
        }


        [HttpGet]
        public ActionResult select(string price, string color, string numchairs, string model, string avaliable)
        {
            var car = db.Cars.Find(model);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost]
        public ActionResult select( Cars car)
        {
            var result = db.Cars.Where(a => a.color.Contains(car.color)
                                         
                                         
                                         || a.model.Contains(car.model)
                                         || a.avaliable.Contains(car.avaliable)).ToList();

            return View(result);
        }

        public ActionResult changeAvailableState(int id)
        {

            var change = db.Cars.Single(a => a.id == id);
            if (change.avaliable == "no")
            {
                change.avaliable = "yes";
            }
            else { change.avaliable = "no"; }

            db.Entry(change).Property("avaliable").IsModified = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //public ActionResult select()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult select(string avaliable , int price, string color, int numchairs, )
        //{
        //    var result = db.Cars.Where(a => a.avaliable.Contains(avaliable)
        //                                 && a.price.ToString().Contains(price)
        //                                 || a.color.Contains(color)
        //                                 || a.numchairs.ToString().Contains(numchairs)
        //                                 || a.model.Contains(SearchName)).ToList();

        //    return View(result);
        //}

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryid = new SelectList(db.categories, "id", "categoryname", cars.categoryid);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cars cars, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = System.IO.Path.Combine(Server.MapPath("~/upload"), upload.FileName);
                upload.SaveAs(path);
                cars.carimg = upload.FileName;
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryid = new SelectList(db.categories, "id", "categoryname", cars.categoryid);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars cars = db.Cars.Find(id);
            db.Cars.Remove(cars);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

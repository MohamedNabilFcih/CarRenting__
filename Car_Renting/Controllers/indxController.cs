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
using Microsoft.AspNet.Identity;
using System.Net.Mail;

namespace Car_Renting.Controllers
{
    public class indxController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: indx
        public ActionResult Index()
        {
            return View(db.categories.ToList());
        }






        // GET: indx/Details/5
        public ActionResult Details(int id)
        {
            var car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            Session["id"] = id;
            return View(car);
        }



        [Authorize]
        public ActionResult rent()
        {

            return View();

        }


        [Authorize]
        [HttpPost]
        public ActionResult rent(string PickUp, string DropOff, string location)
        {
            var UserId = User.Identity.GetUserId();
            var Username = User.Identity.GetUserName();
            var CarId = (int)Session["id"];
            var checkavailability = db.RentCars.Where(a => a.id == CarId && a.car.avaliable == "no" ).ToList();
            if (checkavailability.Count < 1)
            {
                var checkwallet = db.RentCars.Where(a => a.user.wallet > a.car.price).ToList();
                if (checkwallet.Count < 1)
                {
                    var check = db.RentCars.Where(a => a.CarId == CarId && a.UserId == UserId && a.user.wallet > a.car.price).ToList();
                    if (check.Count < 1)
                    {

                        var cars = new RentCar();

                        cars.UserId = UserId;
                        cars.CarId = CarId;
                        cars.PickUp = Convert.ToDateTime(PickUp);
                        cars.DropOff = Convert.ToDateTime(DropOff);
                        cars.location = location;
                        cars.date = DateTime.Now;

                        db.RentCars.Add(cars);
                        db.SaveChanges();
                        

                        var mail = new MailMessage();

                        var loginInfo = new NetworkCredential("mohamed@gmail.com", "000000");
                        mail.From = new MailAddress("site_User@gmail.com");
                        mail.To.Add(new MailAddress("mohamed@gmail.com"));
                        mail.IsBodyHtml = true;
                        string body = "User ID : " + UserId + "<br>" +
                                        "User name : " + Username + "<br>" +
                                        "asked to rent : " + CarId + "<br>" +
                                        " PickUp : " + PickUp + "<br>" +
                                        "DropOff : " + DropOff + "<br>" +
                                        "location : " + location + "<br>" +
                                        "date of request : " + DateTime.Now + "<br>";

                        mail.Body = body;

                        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = loginInfo;
                        smtpClient.Send(mail);


                        ViewBag.Result = "Thanks ! Your Request Is Pending For Admin Accept";
                    }
                    else
                    {
                        ViewBag.Result = "You Can Not Request The Same Car Twice   ";
                    }

                }
                else
                {
                    ViewBag.Result = "Err : your cash is not enough ,,  please check your wallet  ";
                }
            }
            else
            {
                //var txt = new RentCar();
                //db.Cars.Where(a => a.id == CarId).ToList();
                
                ViewBag.Result = "sorry this car is  UnAvailable Now "  ;

            }


            return View();

        }

        [Authorize]
        public ActionResult getUsercars()
        {
            var UserId = User.Identity.GetUserId();
            var cars = db.RentCars.Where(a => a.UserId == UserId);
            return View(cars.ToList());
        }

        [Authorize]
        public ActionResult rentdetails(int id)
        {
            var car = db.RentCars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);

        }

        [Authorize]
        public ActionResult EditRequest(int id)
        {
            var car = db.RentCars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        [HttpPost]
        public ActionResult EditRequest(RentCar car)
        {
            if (ModelState.IsValid)
            {
                car.date = DateTime.Now;
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("getUsercars");

            }
            return View(car);
        }

        // GET: Roles/Delete/5
        public ActionResult DeleteRequest(int id)
        {
            var car = db.RentCars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult DeleteRequest(RentCar car)
        {

            var mycar = db.RentCars.Find(car.id);
            db.RentCars.Remove(mycar);
            db.SaveChanges();
            return RedirectToAction("getUsercars");


        }

        ///////////////////////////////////////////////////////

        //public ActionResult userDetails(int id)
        //{
        //    var user = db..Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Session["id"] = id;
        //    return View(user);
        //}

        //[Authorize]
        //public ActionResult EditUser(int id)
        //{
        //    var car = db.RentCars.Find(id);
        //    if (car == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(car);
        //}

        //[HttpPost]
        //public ActionResult EditUser(RentCar car)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        car.date = DateTime.Now;
        //        db.Entry(car).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("getUsercars");

        //    }
        //    return View(car);
        //}

        //// GET: Roles/Delete/5
        //public ActionResult Deleteuser(int id)
        //{
        //    var car = db.RentCars.Find(id);
        //    if (car == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(car);
        //}

        //// POST: Roles/Delete/5
        //[HttpPost]
        //public ActionResult Deleteuser(RentCar car)
        //{

        //    var mycar = db.RentCars.Find(car.id);
        //    db.RentCars.Remove(mycar);
        //    db.SaveChanges();
        //    return RedirectToAction("getUsercars");


        //}


        ///////////////////////////////////////////////////////


        [Authorize]
        public ActionResult getAllUserRequest()
        {
            var cars = db.RentCars;

            return View(cars.ToList());
        }

        public ActionResult avaliableCar()
        {
            var cars = db.Cars.Where(a => a.avaliable == "yes");

            return View(cars.ToList());
        }

        public ActionResult Non_avaliableCar()
        {
            var cars = db.Cars.Where(a => a.avaliable == "no");

            return View(cars.ToList());
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchName)
        {
            var result = db.Cars.Where(a => a.avaliable.Contains(SearchName)
                                         || a.price.ToString().Contains(SearchName)
                                         || a.color.Contains(SearchName)
                                         || a.category.categoryname.Contains(SearchName)
                                         || a.numchairs.ToString().Contains(SearchName)
                                         || a.model.Contains(SearchName)).ToList();

            return View(result);
        }




        // GET: indx/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: indx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,categoryname,categorydescription")] category category)
        {
            if (ModelState.IsValid)
            {
                db.categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: indx/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: indx/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,categoryname,categorydescription")] category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: indx/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: indx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category category = db.categories.Find(id);
            db.categories.Remove(category);
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

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel Contact)
        {
            var mail = new MailMessage();

            var loginInfo = new NetworkCredential("mohamed.nabil0486@gmail.com", "0000");
            mail.From = new MailAddress(Contact.Email);
            mail.To.Add(new MailAddress("mohamed.nabil0486@gmail.com"));
            mail.IsBodyHtml = true;
            string body = "User Name : " + Contact.Name + "<br>" +
                        "User Email : " + Contact.Email + "<br>" +
                        "User Massage : " + Contact.Massage + "<br>";
            mail.Body = body;
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(mail);

            ViewBag.Result = "massage sent successfully ";
            return View();
        }
    }
}

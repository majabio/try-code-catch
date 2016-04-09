using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3;

namespace WebApplication3.Controllers
{
    public class WorkersController : Controller
    {
        private erschedulerEntities1 db = new erschedulerEntities1();

        // GET: Workers
        public ActionResult Index()
        {
            var worker = db.Worker.Include(w => w.Branches).Include(w => w.Employees).Include(w => w.Gender1).Include(w => w.PlaceOfLiving).Include(w => w.Work_Data);
            return View(worker.ToList());
        }

        // GET: Workers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Branches, "ID", "EmergencyAmbulance");
            ViewBag.ID = new SelectList(db.Employees, "ID", "Employment");
            ViewBag.Gender = new SelectList(db.Gender, "ID", "Gender_type");
            ViewBag.Hometown = new SelectList(db.PlaceOfLiving, "ID", "Name");
            ViewBag.ID = new SelectList(db.Work_Data, "ID", "ID");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,OIB,Birth_Date,Gender,Address,Hometown,Home_Telephone,Mobile_Phone,Note")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Worker.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Branches, "ID", "EmergencyAmbulance", worker.ID);
            ViewBag.ID = new SelectList(db.Employees, "ID", "Employment", worker.ID);
            ViewBag.Gender = new SelectList(db.Gender, "ID", "Gender_type", worker.Gender);
            ViewBag.Hometown = new SelectList(db.PlaceOfLiving, "ID", "Name", worker.Hometown);
            ViewBag.ID = new SelectList(db.Work_Data, "ID", "ID", worker.ID);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Branches, "ID", "EmergencyAmbulance", worker.ID);
            ViewBag.ID = new SelectList(db.Employees, "ID", "Employment", worker.ID);
            ViewBag.Gender = new SelectList(db.Gender, "ID", "Gender_type", worker.Gender);
            ViewBag.Hometown = new SelectList(db.PlaceOfLiving, "ID", "Name", worker.Hometown);
            ViewBag.ID = new SelectList(db.Work_Data, "ID", "ID", worker.ID);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Surname,OIB,Birth_Date,Gender,Address,Hometown,Home_Telephone,Mobile_Phone,Note")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Branches, "ID", "EmergencyAmbulance", worker.ID);
            ViewBag.ID = new SelectList(db.Employees, "ID", "Employment", worker.ID);
            ViewBag.Gender = new SelectList(db.Gender, "ID", "Gender_type", worker.Gender);
            ViewBag.Hometown = new SelectList(db.PlaceOfLiving, "ID", "Name", worker.Hometown);
            ViewBag.ID = new SelectList(db.Work_Data, "ID", "ID", worker.ID);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Worker.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Worker.Find(id);
            db.Worker.Remove(worker);
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

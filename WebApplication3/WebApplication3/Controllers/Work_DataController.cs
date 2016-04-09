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
    public class Work_DataController : Controller
    {
        private erschedulerEntities1 db = new erschedulerEntities1();

        // GET: Work_Data
        public ActionResult Index()
        {
            var work_Data = db.Work_Data.Include(w => w.Worker);
            return View(work_Data.ToList());
        }

        // GET: Work_Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Data work_Data = db.Work_Data.Find(id);
            if (work_Data == null)
            {
                return HttpNotFound();
            }
            return View(work_Data);
        }

        // GET: Work_Data/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Worker, "ID", "Name");
            return View();
        }

        // POST: Work_Data/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Shift_Date_End,Shift_Time_End")] Work_Data work_Data)
        {
            if (ModelState.IsValid)
            {
                db.Work_Data.Add(work_Data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Worker, "ID", "Name", work_Data.ID);
            return View(work_Data);
        }

        // GET: Work_Data/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Data work_Data = db.Work_Data.Find(id);
            if (work_Data == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Worker, "ID", "Name", work_Data.ID);
            return View(work_Data);
        }

        // POST: Work_Data/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Shift_Date_End,Shift_Time_End")] Work_Data work_Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Worker, "ID", "Name", work_Data.ID);
            return View(work_Data);
        }

        // GET: Work_Data/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Data work_Data = db.Work_Data.Find(id);
            if (work_Data == null)
            {
                return HttpNotFound();
            }
            return View(work_Data);
        }

        // POST: Work_Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work_Data work_Data = db.Work_Data.Find(id);
            db.Work_Data.Remove(work_Data);
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

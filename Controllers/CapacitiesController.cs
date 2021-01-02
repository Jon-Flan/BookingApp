using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Booking_App.Models;
using Booking_App.Models.DAL;

namespace Booking_App.Controllers
{
    public class CapacitiesController : Controller
    {
        private Booking_AppContext db = new Booking_AppContext();

        // GET: Capacities
        public ActionResult Index()
        {
            var capacitys = db.Capacitys.Include(c => c.Company);
            return View(capacitys.ToList());
        }

        // GET: Capacities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacity capacity = db.Capacitys.Find(id);
            if (capacity == null)
            {
                return HttpNotFound();
            }
            return View(capacity);
        }

        // GET: Capacities/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name");
            return View();
        }

        // POST: Capacities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,max_capacity,max_per_group,max_stay_length")] Capacity capacity)
        {
            if (ModelState.IsValid)
            {
                db.Capacitys.Add(capacity);
                db.SaveChanges();
                return RedirectToAction("Create","Company_Hours");
            }

            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name", capacity.CompanyID);
            return View(capacity);
        }

        // GET: Capacities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacity capacity = db.Capacitys.Find(id);
            if (capacity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name", capacity.CompanyID);
            return View(capacity);
        }

        // POST: Capacities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,max_capacity,max_per_group,max_stay_length")] Capacity capacity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capacity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name", capacity.CompanyID);
            return View(capacity);
        }

        // GET: Capacities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Capacity capacity = db.Capacitys.Find(id);
            if (capacity == null)
            {
                return HttpNotFound();
            }
            return View(capacity);
        }

        // POST: Capacities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Capacity capacity = db.Capacitys.Find(id);
            db.Capacitys.Remove(capacity);
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

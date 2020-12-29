using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingApp.Models;

namespace BookingApp.Controllers
{
    public class SchedulerEventsController : Controller
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: SchedulerEvents
        public ActionResult Index()
        {
            return View(db.SchedulerEvents.ToList());
        }

        // GET: SchedulerEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchedulerEvent schedulerEvent = db.SchedulerEvents.Find(id);
            if (schedulerEvent == null)
            {
                return HttpNotFound();
            }
            return View(schedulerEvent);
        }

        // GET: SchedulerEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchedulerEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,StartDate,EndDate")] SchedulerEvent schedulerEvent)
        {
            if (ModelState.IsValid)
            {
                db.SchedulerEvents.Add(schedulerEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedulerEvent);
        }

        // GET: SchedulerEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchedulerEvent schedulerEvent = db.SchedulerEvents.Find(id);
            if (schedulerEvent == null)
            {
                return HttpNotFound();
            }
            return View(schedulerEvent);
        }

        // POST: SchedulerEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,StartDate,EndDate")] SchedulerEvent schedulerEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedulerEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedulerEvent);
        }

        // GET: SchedulerEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchedulerEvent schedulerEvent = db.SchedulerEvents.Find(id);
            if (schedulerEvent == null)
            {
                return HttpNotFound();
            }
            return View(schedulerEvent);
        }

        // POST: SchedulerEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchedulerEvent schedulerEvent = db.SchedulerEvents.Find(id);
            db.SchedulerEvents.Remove(schedulerEvent);
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

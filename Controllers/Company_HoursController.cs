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
    public class Company_HoursController : Controller
    {
        private Booking_AppContext db = new Booking_AppContext();

        // GET: Company_Hours
        public ActionResult Index()
        {
            var company_Hours = db.Company_Hours.Include(c => c.Company);
            return View(company_Hours.ToList());
        }

        // GET: Company_Hours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Hour company_Hour = db.Company_Hours.Find(id);
            if (company_Hour == null)
            {
                return HttpNotFound();
            }
            return View(company_Hour);
        }

        // GET: Company_Hours/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name");
            return View();
        }

        // POST: Company_Hours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Day,OpenTime,CloseTime,CompanyID")] Company_Hour company_Hour)
        {
            if (ModelState.IsValid)
            {
                db.Company_Hours.Add(company_Hour);
                db.SaveChanges();
                return RedirectToAction("Details","Companies",new { id = company_Hour.CompanyID});
            }

            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name", company_Hour.CompanyID);
            return View(company_Hour);
        }

        // GET: Company_Hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Hour company_Hour = db.Company_Hours.Find(id);
            if (company_Hour == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name", company_Hour.CompanyID);
            return View(company_Hour);
        }

        // POST: Company_Hours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Day,OpenTime,CloseTime,CompanyID")] Company_Hour company_Hour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Hour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Companies", new { id = company_Hour.CompanyID });
            }
            ViewBag.CompanyID = new SelectList(db.Companys, "ID", "Name", company_Hour.CompanyID);
            return View(company_Hour);
        }

        // GET: Company_Hours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Hour company_Hour = db.Company_Hours.Find(id);
            if (company_Hour == null)
            {
                return HttpNotFound();
            }
            return View(company_Hour);
        }

        // POST: Company_Hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company_Hour company_Hour = db.Company_Hours.Find(id);
            db.Company_Hours.Remove(company_Hour);
            db.SaveChanges();
            return RedirectToAction("Details", "Companies", new { id = company_Hour.CompanyID });
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

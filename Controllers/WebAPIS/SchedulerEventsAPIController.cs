using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookingApp.Models;

namespace BookingApp.Controllers.WebAPIS
{
    public class SchedulerEventsAPIController : ApiController
    {
        private SchedulerContext db = new SchedulerContext();

        // GET: api/SchedulerEventsAPI
        public IQueryable<SchedulerEvent> GetSchedulerEvents()
        {
            return db.SchedulerEvents.Include(b => b.Company); ;
        }

        // GET: api/SchedulerEventsAPI/5
        [ResponseType(typeof(SchedulerEvent))]
        public IHttpActionResult GetSchedulerEvent(int id)
        {
            SchedulerEvent schedulerEvent = db.SchedulerEvents.Find(id);
            if (schedulerEvent == null)
            {
                return NotFound();
            }

            return Ok(schedulerEvent);
        }

        // PUT: api/SchedulerEventsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchedulerEvent(int id, SchedulerEvent schedulerEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schedulerEvent.Id)
            {
                return BadRequest();
            }

            db.Entry(schedulerEvent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedulerEventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SchedulerEventsAPI
        [ResponseType(typeof(SchedulerEvent))]
        public IHttpActionResult PostSchedulerEvent(SchedulerEvent schedulerEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SchedulerEvents.Add(schedulerEvent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = schedulerEvent.Id }, schedulerEvent);
        }

        // DELETE: api/SchedulerEventsAPI/5
        [ResponseType(typeof(SchedulerEvent))]
        public IHttpActionResult DeleteSchedulerEvent(int id)
        {
            SchedulerEvent schedulerEvent = db.SchedulerEvents.Find(id);
            if (schedulerEvent == null)
            {
                return NotFound();
            }

            db.SchedulerEvents.Remove(schedulerEvent);
            db.SaveChanges();

            return Ok(schedulerEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchedulerEventExists(int id)
        {
            return db.SchedulerEvents.Count(e => e.Id == id) > 0;
        }
    }
}
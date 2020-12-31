using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Booking_App.Models;
using Booking_App.Models.DAL;
using Booking_App.Models.DTO;


namespace Booking_App.Controllers.WebAPI
{
    public class BookingsAPIController : ApiController
    {
        private Booking_AppContext db = new Booking_AppContext();

        // GET: api/BookingsAPI
        public IQueryable<BookingsDTO> GetBookings()
        {
            var bookings = from b in db.Bookings
                           select new BookingsDTO()
                           {
                                ID = b.ID,
                                party_name = b.party_name,
                                Date = b.Date,
                                Time = b.Time,
                                NumPeople = b.NumPeople,
                                FName = b.FName,
                                LName = b.LName,
                                Email = b.Email,
                                Phone = b.Phone,
                                CompanyID = b.CompanyID,
                                Company = b.Company
                            };

            return bookings;
        }

        // GET: api/BookingsAPI/5
        [ResponseType(typeof(BookingsDTO))]
        public async Task<IHttpActionResult> GetBooking(int id)
        {
            var booking = await db.Bookings.Select(b =>
                new BookingsDTO()
                {
                    ID = b.ID,
                    party_name = b.party_name,
                    Date = b.Date,
                    Time = b.Time,
                    NumPeople = b.NumPeople,
                    FName = b.FName,
                    LName = b.LName,
                    Email = b.Email,
                    Phone = b.Phone,
                    CompanyID = b.CompanyID,
                    Company = b.Company
                }).SingleOrDefaultAsync(b => b.ID == id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/BookingsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(int id, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.ID)
            {
                return BadRequest();
            }

            db.Entry(booking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/BookingsAPI
        [ResponseType(typeof(BookingsDTO))]
        public async Task<IHttpActionResult> PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();

            db.Entry(booking).Reference(x => x.Company).Load();

            var dto = new BookingsDTO()
            {
                ID = booking.ID,
                party_name = booking.party_name,
                Date = booking.Date,
                Time = booking.Time,
                NumPeople = booking.NumPeople,
                FName = booking.FName,
                LName = booking.LName,
                Email = booking.Email,
                Phone = booking.Phone,
                CompanyID = booking.CompanyID,
                Company = booking.Company
            };

            return CreatedAtRoute("DefaultApi", new { id = booking.ID }, dto);
        }

        // DELETE: api/BookingsAPI/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult DeleteBooking(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.Bookings.Remove(booking);
            db.SaveChanges();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int id)
        {
            return db.Bookings.Count(e => e.ID == id) > 0;
        }
    }
}
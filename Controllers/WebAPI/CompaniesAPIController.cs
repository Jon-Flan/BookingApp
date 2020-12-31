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
    public class CompaniesAPIController : ApiController
    {
        private Booking_AppContext db = new Booking_AppContext();

        // GET: api/CompaniesAPI
        public IQueryable<CompanyDTO> GetCompanys()
        {
            var companys = from b in db.Companys
                           select new CompanyDTO()
                           {
                               ID = b.ID,
                               Name = b.Name,
                               Address = b.Address,
                               Phone = b.Phone,
                               Capacity = b.Capacity,
                               CapacityID = b.CapacityID,
                               Hours = b.Hours,
                               Bookings = b.Bookings
                           };
            return companys;
        }

        // GET: api/CompaniesAPI/5
        [ResponseType(typeof(CompanyDTO))]
        public async Task<IHttpActionResult> GetCompany(int id)
        {
            var company = await db.Companys.Select(b =>
                new CompanyDTO()
                {
                    ID = b.ID,
                    Name = b.Name,
                    Address = b.Address,
                    Phone = b.Phone,
                    Capacity = b.Capacity,
                    CapacityID = b.CapacityID,
                    Hours = b.Hours,
                    Bookings = b.Bookings
                }).SingleOrDefaultAsync(b => b.ID == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/CompaniesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.ID)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/CompaniesAPI
        [ResponseType(typeof(CompanyDTO))]
        public async Task<IHttpActionResult> PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companys.Add(company);
            await db.SaveChangesAsync();

            db.Entry(company).Reference(x => x.Capacity).Load();
            db.Entry(company).Reference(x => x.Hours).Load();

            var dto = new CompanyDTO()
            {
                ID = company.ID,
                Name = company.Name,
                Address = company.Address,
                Phone = company.Phone,
                Capacity = company.Capacity,
                CapacityID = company.CapacityID,
                Hours = company.Hours
            };

            return CreatedAtRoute("DefaultApi", new { id = company.ID }, dto);
        }

        // DELETE: api/CompaniesAPI/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companys.Remove(company);
            db.SaveChanges();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companys.Count(e => e.ID == id) > 0;
        }
    }
}
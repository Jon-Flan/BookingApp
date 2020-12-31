using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking_App.Models.DTO
{
    public class CompanyDTO
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        //Forgein Key Relation
        public int CapacityID { get; set; }
        //Navigation property
        public Capacity Capacity { get; set; }

        public virtual ICollection<Company_Hour> Hours { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
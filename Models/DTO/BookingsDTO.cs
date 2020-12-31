using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking_App.Models.DTO
{
    public class BookingsDTO
    {
        public int ID { get; set; }
        public string party_name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int NumPeople { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //Forgein Key 
        public int CompanyID { get; set; }
        //Navigation Property
        public virtual Company Company { get; set; }
    }
}
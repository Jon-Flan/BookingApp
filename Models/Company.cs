using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking_App.Models
{
    public class Company
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string Address { get; set; }
        [StringLength(25, ErrorMessage = "First name cannot be longer than 25 characters.")]
        public string Phone { get; set; }

        //Forgein Key Relation
        public int CapacityID { get; set; }
        //Navigation property
        public Capacity Capacity { get; set; }

        public virtual ICollection<Company_Hour> Hours { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
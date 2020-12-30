using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class SchedulerEvent
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Num_Guests { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        //Forgein Key
        public int CompanyID { get; set; }
        //Navigation property
        public Company Company { get; set; }

    }
}
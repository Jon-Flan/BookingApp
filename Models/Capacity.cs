﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Booking_App.Models
{
    public class Capacity
    {
        [Key]
        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        [Required]
        public int max_capacity { get; set; }
        [Required]
        public int max_per_group{ get; set; }
        [Required]
        public int max_stay_length { get; set; }

        public virtual Company Company { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_App.Models
{
    public class Company_Hour
    {

        [Required]
        public int ID { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime OpenTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime CloseTime { get; set; }
        //Forgein Key 
        public int CompanyID { get; set; }
        //Navigation Property
        public virtual Company Company { get; set; }

    }
}
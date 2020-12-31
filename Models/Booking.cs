using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_App.Models
{
    public class Booking
    {

        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string party_name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }
        [Required]
        public int NumPeople { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Name cannot be longer than 25 characters.")]
        public string FName { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Name cannot be longer than 25 characters.")]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Phone cannot be longer than 25 characters.")]
        public string Phone { get; set; }

        //Forgein Key 
        public int CompanyID { get; set; }
        //Navigation Property
        public virtual Company Company { get; set; }
    }
}
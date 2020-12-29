using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Company
    {

        private ICollection<SchedulerEvent> _events;


        public Company()
        {
            _events = new List<SchedulerEvent>();

        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }

        public virtual ICollection<SchedulerEvent> SchedulerEvents
        {
            get { return _events; }
            set { _events = value; }
        }
    }
}
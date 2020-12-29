using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class SchedulerEvent
    {
        private ICollection<Company> _companys;

        public SchedulerEvent()
        {
            _companys = new List<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int Num_Guests { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Company> Companys
        {
            get { return _companys; }
            set { _companys = value; }
        }
    }
}
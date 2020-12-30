using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class WebAPIEvent
    {
        public int id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        //Forgein Key
        public int CompanyID { get; set; }
        //Navigation property
        public Company Company { get; set; }

        public static explicit operator WebAPIEvent(SchedulerEvent schedulerEvent)
        {
            return new WebAPIEvent
            {
                id = schedulerEvent.Id,
                text = schedulerEvent.Name,
                start_date = schedulerEvent.StartDate.ToString("yyyy-MM-dd HH:mm"),
                end_date = schedulerEvent.EndDate.ToString("yyyy-MM-dd HH:mm"),
                CompanyID = schedulerEvent.CompanyID
            };
        }

        public static explicit operator SchedulerEvent(WebAPIEvent schedulerEvent)
        {
            return new SchedulerEvent
            {
                Id = schedulerEvent.id,
                Name = schedulerEvent.text,
                StartDate = DateTime.Parse(
                    schedulerEvent.start_date,
                    System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.Parse(
                    schedulerEvent.end_date,
                    System.Globalization.CultureInfo.InvariantCulture),
                CompanyID = schedulerEvent.CompanyID
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookingApp.Models
{
    public class SchedulerContext : DbContext
    {

        public SchedulerContext() : base("SchedulerContext")
        {

        }
        public DbSet<SchedulerEvent> SchedulerEvents { get; set; }
        public DbSet<Company> Companys { get; set; }
    }
}
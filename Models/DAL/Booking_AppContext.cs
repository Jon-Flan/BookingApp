using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Booking_App.Models;

namespace Booking_App.Models.DAL
{
    public class Booking_AppContext: DbContext
    {
        public Booking_AppContext() : base("Booking_AppContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Capacity> Capacitys { get; set; }
        public DbSet<Company_Hour> Company_Hours { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
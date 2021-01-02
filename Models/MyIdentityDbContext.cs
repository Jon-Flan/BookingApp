using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking_App.Models
{
    public class MyIdentityDbContext : IdentityDbContext<AppUser>
    {
        public MyIdentityDbContext():base("Booking_AppContext", throwIfV1Schema: false)
        {

        }

        public static MyIdentityDbContext Create()
        {
            return new MyIdentityDbContext();
        }
    }
}
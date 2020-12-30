namespace BookingApp.Migrations
{
    using System;
    using BookingApp.Models;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<BookingApp.Models.SchedulerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BookingApp.Models.SchedulerContext";
        }

        protected override void Seed(BookingApp.Models.SchedulerContext context)
        {

            context.Companys.AddOrUpdate(x => x.CompanyId,
                new Company() { CompanyId = 1, CompanyName = "Best Restaraunt", CompanyAddress = "1 Henry Street, Dublin 1" },
                new Company() { CompanyId = 2, CompanyName = "Tommys Kitchen", CompanyAddress = "15 Rathmines Road, Dublin 6" },
                new Company() { CompanyId = 3, CompanyName = "Bondi Burgers", CompanyAddress = "Unit 23 Blanchardstown Centre, Dublin 15" },
                new Company() { CompanyId = 4, CompanyName = "Pappis Pizza", CompanyAddress = "Unit 18 Dundrum Centre, Dublin 18" }
                );

            context.SchedulerEvents.AddOrUpdate(x => x.Id,
                  new SchedulerEvent()
                  {
                      Id = 1,
                      Name = "Paul Grimmes",
                      Num_Guests = 6,
                      StartDate = new DateTime(2021, 1, 17, 3, 0, 0),
                      EndDate = new DateTime(2021, 1, 17, 6, 0, 0),
                      CompanyID = 1
                  },

                new SchedulerEvent()
                {
                    Id = 2,
                    Name = "Barnakle Bill",
                    Num_Guests = 2,
                    StartDate = new DateTime(2021, 1, 15, 1, 0, 0),
                    EndDate = new DateTime(2021, 1, 15, 2, 0, 0),
                    CompanyID = 1
                },

                new SchedulerEvent()
                {
                    Id = 3,
                    Name = "Mariah Walsh",
                    Num_Guests = 5,
                    StartDate = new DateTime(2021, 1, 21, 4, 0, 0),
                    EndDate = new DateTime(2021, 1, 21, 5, 0, 0),
                    CompanyID = 2
                },

                new SchedulerEvent()
                {
                    Id = 4,
                    Name = "Lucy Windgate",
                    Num_Guests = 3,
                    StartDate = new DateTime(2021, 1, 19, 7, 0, 0),
                    EndDate = new DateTime(2021, 1, 19, 9, 0, 0),
                    CompanyID = 3
                },

                new SchedulerEvent()
                {
                    Id = 5,
                    Name = "Stephen McKinley",
                    Num_Guests = 4,
                    StartDate = new DateTime(2021, 1, 02, 4, 0, 0),
                    EndDate = new DateTime(2021, 1, 02, 6, 0, 0),
                    CompanyID = 3
                },

                new SchedulerEvent()
                {
                    Id = 6,
                    Name = "Fiona Gill",
                    Num_Guests = 4,
                    StartDate = new DateTime(2021, 1, 02, 5, 0, 0),
                    EndDate = new DateTime(2021, 1, 02, 7, 0, 0),
                    CompanyID = 4
                }
                );

            
        }
        
    }
}

namespace BookingApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using BookingApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BookingApp.Models.SchedulerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BookingApp.Models.SchedlerContext";
        }

        protected override void Seed(BookingApp.Models.SchedulerContext context)
        {
            List<SchedulerEvent> events = new List<SchedulerEvent>()
            {
                new SchedulerEvent()
                {
                    Id = 1,
                    Text = "Event 1",
                    StartDate = new DateTime(2021, 1, 15, 2, 0, 0),
                    EndDate = new DateTime(2021, 1, 15, 4, 0, 0)
                },
                new SchedulerEvent()
                {
                    Id = 2,
                    Text = "Event 2",
                    StartDate = new DateTime(2021, 1, 17, 3, 0, 0),
                    EndDate = new DateTime(2021, 1, 17, 6, 0, 0)
                },
                new SchedulerEvent()
                {
                    Id = 3,
                    Text = "Multiday event",
                    StartDate = new DateTime(2021, 1, 15, 0, 0, 0),
                    EndDate = new DateTime(2021, 1, 20, 0, 0, 0)
                }
            };

            events.ForEach(s => context.SchedulerEvents.Add(s));
            context.SaveChanges();
        }
    }
}

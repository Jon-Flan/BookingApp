namespace Booking_App.Migrations
{
    using System;
    using Booking_App.Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Booking_App.Models.DAL.Booking_AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Booking_App.Models.DAL.BookingAppContext";
        }

        protected override void Seed(Booking_App.Models.DAL.Booking_AppContext context)
        {
            //Datasbe seeding.

            //Seed tthe Company Table
            context.Companys.AddOrUpdate(x => x.ID,
                new Company()
                {
                    ID = 1,
                    Name = "Best Restaurant",
                    Address = "1 Henry Street, Dublin 1",
                    Phone = "01-8076943",
                    CapacityID = 1
                },
                new Company() 
                { 
                    ID = 2, 
                    Name = "Tommys Kitchen", 
                    Address = "15 Rathmines Road, Dublin 6",
                    Phone = "01-8076943",
                    CapacityID = 2
                },
                new Company() 
                { 
                    ID = 3, 
                    Name = "Bondi Burgers", 
                    Address = "Unit 23 Blanchardstown Centre, Dublin 15",
                    Phone = "01-8076943",
                    CapacityID = 3
                },
                new Company() 
                { 
                    ID= 4, 
                    Name = "Pappis Pizza", 
                    Address = "Unit 18 Dundrum Centre, Dublin 18",
                    Phone = "01-8076943",
                    CapacityID = 4
                });


            //Seed the Capacity details for each comnpany
            context.Capacitys.AddOrUpdate(x => x.ID,
                new Capacity() 
                {
                  ID = 1,
                  max_capacity = 50,
                  max_per_group = 5,
                  max_stay_length = 90
                },
                new Capacity()
                {
                    ID = 2,
                    max_capacity = 40,
                    max_per_group = 6,
                    max_stay_length = 60
                },
                new Capacity()
                {
                    ID = 3,
                    max_capacity = 25,
                    max_per_group = 5,
                    max_stay_length = 60
                },
                new Capacity()
                {
                    ID = 4,
                    max_capacity = 55,
                    max_per_group = 6,
                    max_stay_length = 90
                });

            //Seed the Opening hours table for each company
            context.Company_Hours.AddOrUpdate(x => x.ID,
                new Company_Hour() 
                { 
                    ID = 1,
                    Day = 1,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 1
                },
                new Company_Hour()
                {
                    ID = 2,
                    Day = 2,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 1
                },
                new Company_Hour()
                {
                    ID = 3,
                    Day = 3,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 1
                },
                new Company_Hour()
                {
                    ID = 4,
                    Day = 4,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 1
                },
                new Company_Hour()
                {
                    ID = 5,
                    Day = 5,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 1
                },
                 new Company_Hour()
                 {
                     ID = 6,
                     Day = 1,
                     OpenTime = DateTime.Parse("10:00"),
                     CloseTime = DateTime.Parse("21:00"),
                     CompanyID = 2
                 },
                new Company_Hour()
                {
                    ID = 7,
                    Day = 2,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 2
                },
                new Company_Hour()
                {
                    ID = 8,
                    Day = 3,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 2
                },
                new Company_Hour()
                {
                    ID = 9,
                    Day = 4,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 2
                },
                new Company_Hour()
                {
                    ID = 10,
                    Day = 5,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 2
                },
                 new Company_Hour()
                 {
                     ID = 11,
                     Day = 1,
                     OpenTime = DateTime.Parse("09:00"),
                     CloseTime = DateTime.Parse("20:00"),
                     CompanyID = 3
                 },
                new Company_Hour()
                {
                    ID = 12,
                    Day = 2,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 3
                },
                new Company_Hour()
                {
                    ID = 13,
                    Day = 3,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 3
                },
                new Company_Hour()
                {
                    ID = 14,
                    Day = 4,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 3
                },
                new Company_Hour()
                {
                    ID = 15,
                    Day = 5,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("20:00"),
                    CompanyID = 3
                },
                new Company_Hour()
                {
                    ID = 16,
                    Day = 6,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("22:00"),
                    CompanyID = 3
                },
                new Company_Hour()
                {
                    ID = 17,
                    Day = 7,
                    OpenTime = DateTime.Parse("09:00"),
                    CloseTime = DateTime.Parse("22:00"),
                    CompanyID = 3
                },
                 new Company_Hour()
                 {
                     ID = 18,
                     Day = 1,
                     OpenTime = DateTime.Parse("10:00"),
                     CloseTime = DateTime.Parse("21:00"),
                     CompanyID = 4
                 },
                new Company_Hour()
                {
                    ID = 19,
                    Day = 2,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 4
                },
                new Company_Hour()
                {
                    ID = 20,
                    Day = 3,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 4
                },
                new Company_Hour()
                {
                    ID = 21,
                    Day = 4,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 4
                },
                new Company_Hour()
                {
                    ID = 22,
                    Day = 5,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 4
                },
                new Company_Hour()
                {
                    ID = 23,
                    Day = 6,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("23:00"),
                    CompanyID = 4
                },
                new Company_Hour()
                {
                    ID = 24,
                    Day = 7,
                    OpenTime = DateTime.Parse("10:00"),
                    CloseTime = DateTime.Parse("21:00"),
                    CompanyID = 4
                });


            //Seed the Bookings Table
            context.Bookings.AddOrUpdate(x => x.ID,
                new Booking() 
                { 
                    ID =1,
                    party_name = "Paul Grimmes",
                    Date  = DateTime.Parse("2021-01-09"),
                    Time = DateTime.Parse("15:00"),
                    NumPeople = 3,
                    CompanyID = 1,
                    FName = "Paul",
                    LName = "Grimmes",
                    Email = "pgrimmes@icloud.com",
                    Phone = "083-1456987"
                },
                 new Booking()
                 {
                     ID = 2,
                     party_name = "Barnakles Party",
                     Date = DateTime.Parse("2021-01-12"),
                     Time = DateTime.Parse("19:00"),
                     NumPeople = 3,
                     CompanyID = 1,
                     FName = "Barnakle",
                     LName = "Bill",
                     Email = "barnakles@gmail.com",
                     Phone = "085-78965412"
                 },
                 new Booking()
                 {
                     ID = 3,
                     party_name = "Mariahs 40th",
                     Date = DateTime.Parse("2021-01-02"),
                     Time = DateTime.Parse("20:00"),
                     NumPeople = 4,
                     CompanyID = 1,
                     FName = "Mariah",
                     LName = "Walsh",
                     Email = "mariah995@hotmail.com",
                     Phone = "087-8743125"
                 },
                 new Booking()
                 {
                     ID = 4,
                     party_name = "Lucys Friends",
                     Date = DateTime.Parse("2021-01-07"),
                     Time = DateTime.Parse("15:00"),
                     NumPeople = 3,
                     CompanyID = 2,
                     FName = "Lucy",
                     LName = "Windgate",
                     Email = "windylucy@hotmail.com",
                     Phone = "086-8461274"
                 },
                 new Booking()
                 {
                     ID = 5,
                     party_name = "Ste's Dinner",
                     Date = DateTime.Parse("2021-01-10"),
                     Time = DateTime.Parse("19:00"),
                     NumPeople = 3,
                     CompanyID = 2,
                     FName = "Stephen",
                     LName = "McKinley",
                     Email = "ste.mack@gmail.com",
                     Phone = "085-0463269"
                 },
                 new Booking()
                 {
                     ID = 6,
                     party_name = "Fifi's ",
                     Date = DateTime.Parse("2021-01-03"),
                     Time = DateTime.Parse("20:30"),
                     NumPeople = 4,
                     CompanyID = 2,
                     FName = "Fiona",
                     LName = "Gill",
                     Email = "gill.f@hotmail.co.uk",
                     Phone = "087-7447847"
                 },
                 new Booking()
                 {
                     ID = 7,
                     party_name = "Dinner Time",
                     Date = DateTime.Parse("2021-01-09"),
                     Time = DateTime.Parse("19:30"),
                     NumPeople = 4,
                     CompanyID = 3,
                     FName = "Greg",
                     LName = "Samsonite",
                     Email = "samsonit44@gmail.com",
                     Phone = "086-4169956"
                 },
                 new Booking()
                 {
                     ID = 8,
                     party_name = "Neils Party",
                     Date = DateTime.Parse("2021-01-12"),
                     Time = DateTime.Parse("19:00"),
                     NumPeople = 3,
                     CompanyID = 3,
                     FName = "Neil",
                     LName = "Ftiz",
                     Email = "fitzer22@icloud.com",
                     Phone = "086-8788595"
                 },
                 new Booking()
                 {
                     ID = 9,
                     party_name = "Leah's Christining",
                     Date = DateTime.Parse("2021-01-02"),
                     Time = DateTime.Parse("12:00"),
                     NumPeople = 4,
                     CompanyID = 3,
                     FName = "Leah",
                     LName = "Roche",
                     Email = "leah.roche11@outlook.com",
                     Phone = "086-7414112"
                 },
                 new Booking()
                 {
                     ID = 10,
                     party_name = "Sams Lunch",
                     Date = DateTime.Parse("2021-01-07"),
                     Time = DateTime.Parse("13:00"),
                     NumPeople = 2,
                     CompanyID = 4,
                     FName = "Sam",
                     LName = "Jones",
                     Email = "jonsey54@gmail.com",
                     Phone = "087-7744115"
                 },
                 new Booking()
                 {
                     ID = 11,
                     party_name = "Claires Do!",
                     Date = DateTime.Parse("2021-01-06"),
                     Time = DateTime.Parse("17:00"),
                     NumPeople = 4,
                     CompanyID = 4,
                     FName = "Claire",
                     LName = "Doyle",
                     Email = "c.doyle@electricireland.ie",
                     Phone = "085-2265498"
                 },
                 new Booking()
                 {
                     ID = 12,
                     party_name = "Lunch Meeting",
                     Date = DateTime.Parse("2021-01-05"),
                     Time = DateTime.Parse("14:00"),
                     NumPeople = 4,
                     CompanyID = 4,
                     FName = "Robert",
                     LName = "Choi",
                     Email = "robert.choi@workEmail.com",
                     Phone = "086-8874921"
                 });

        }
    }
}

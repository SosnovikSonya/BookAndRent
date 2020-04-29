using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAndRent.Repository.SqlRepository
{
    public class BookAndRentDBContext : DbContext
    {
        public BookAndRentDBContext(DbContextOptions<BookAndRentDBContext> options) : base(options)
        {

        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().ToTable("Apartment");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Picture>().ToTable("Picture");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<AvailableDate>().ToTable("AvailableDate");
        }

        public void AddOrUpdate(ITable source)
        {
            var tableType = source.GetType();

            var target = Find(tableType, source.Id);

            if (target == null)
            {
                target = source;
                Attach(target);
            }

            foreach (var prop in tableType.GetProperties())
            {
                var propValue = prop.GetValue(source);
                if (prop.PropertyType.IsValueType)
                {
                    prop.SetValue(target, prop.GetValue(source));
                }               
            }
        }

        public void InitializeDemoData()
        {            
            Users.AddRange(
                new User
                {
                    FirstName = "Пупа"                    
                },
                new User
                {
                    FirstName = "Лупа"
                });

            SaveChanges();

            Apartments.Add(
                new Apartment
                {
                    Address = "улица пушкина дом Колотушкина",
                    Description = "Description",
                    RoomAmount = 3,
                    SleepingPlaces = 5,
                    CostPerNight = 100,
                    Title = "Лучший бордель того города",
                    Coordinates = "zhopa",
                    User = Users.ToList().Single(user => user.FirstName == "Пупа"),
                    AvailableDates = new List<AvailableDate>
                    {
                        new AvailableDate
                        {
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.UtcNow.AddDays(30)
                        }
                    },
                    //ApartmentFacilities = new List<ApartmentFacility>
                    //{
                    //    new ApartmentFacility
                    //    {
                    //        FacilityId = Facilities.ToList()[0].FacilityId
                    //    }
                    //},
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Content = "hueta",
                            User = Users.ToList()[1],
                            Date = DateTime.UtcNow                             
                        }
                    }
                });

            SaveChanges();

            Contracts.Add(new Contract
            {
                Apartment = Apartments.ToList()[0],
                CheckIn = DateTime.UtcNow.AddDays(1),
                CheckOut = DateTime.UtcNow.AddDays(4),
                ContractDate = DateTime.UtcNow,
                Holder = Users.ToList()[0],
                Renter  = Users.ToList()[1],
            });
            SaveChanges();
        }
    }
}

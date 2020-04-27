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
        //public DbSet<Facility> Facilities { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<AvailableDate> AvailableDates { get; set; }
        //public DbSet<ApartmentFacility> ApartmentFacilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().ToTable("Apartment");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Picture>().ToTable("Picture");
            //modelBuilder.Entity<Facility>().ToTable("Facility");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<AvailableDate>().ToTable("AvailableDate");
           // modelBuilder.Entity<ApartmentFacility>().ToTable("ApartmentFacility");
        }

        public void InitializeDemoData()
        {
            //Facilities.AddRange(
            //    new Facility
            //    {
            //        Title = "Интернет"
            //    },
            //    new Facility
            //    {
            //        Title = "Фен"
            //    }
            //);
            
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
                    UserId = Users.ToList().Single(user => user.FirstName == "Пупа").Id,
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
                            UserId = Users.ToList()[1].Id,
                            Date = DateTime.UtcNow                             
                        }
                    }
                });

            SaveChanges();

            Contracts.Add(new Contract
            {
                ApartmentId = Apartments.ToList()[0].Id,
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

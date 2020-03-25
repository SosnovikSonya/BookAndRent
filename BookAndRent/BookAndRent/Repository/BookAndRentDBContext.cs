using BookAndRent.Models.Implementations;
using BookAndRent.Models.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndRent.Repository
{
    public class BookAndRentDBContext : DbContext
    {
        public BookAndRentDBContext(DbContextOptions<BookAndRentDBContext> options) : base(options)
        {
            
        }

        public DbSet<Apartment> Apartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().ToTable("Apartment");
            modelBuilder.Entity<Comment>().ToTable("Comment");
        }
    }
}

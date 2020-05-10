using Microsoft.EntityFrameworkCore;

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
        
    }
}

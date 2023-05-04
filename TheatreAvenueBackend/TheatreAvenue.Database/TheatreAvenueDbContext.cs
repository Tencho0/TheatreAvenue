using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Database
{   //Represents a DbContext used to interact with a database.
    public class TheatreAvenueDbContext : DbContext, IDesignTimeDbContextFactory<TheatreAvenueDbContext>
    {
        public TheatreAvenueDbContext()
        { }

        public TheatreAvenueDbContext(DbContextOptions<TheatreAvenueDbContext> options)
            : base(options)
        { }

        public TheatreAvenueDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TheatreAvenueDbContext>();
            //creates the database = theatreAvenue
            optionsBuilder.UseSqlServer("Server=(local);Database=theatreAvenue;Trusted_Connection=True;");
            return new TheatreAvenueDbContext(optionsBuilder.Options);
        }
        // DbSet properties for each entity in the database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<TheatreEvent> TheatreEvents { get; set; }

        public virtual DbSet<Venue> Venues { get; set; }

        public virtual DbSet<Seat> Seats { get; set; }

        public virtual DbSet<Location> Locations { get; set; }
    }
}

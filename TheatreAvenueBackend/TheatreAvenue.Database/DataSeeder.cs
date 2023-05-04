using Microsoft.EntityFrameworkCore;

namespace TheatreAvenue.Database
{
    // Provides methods for seeding data into a database.
    public class DataSeeder 
    {
        public static void SeedData(TheatreAvenueDbContext context) // Seeds data into the specified TheatreAvenueDbContext.
        {
            // Applies any pending migrations to the database and seeds data into it.
            context.Database.Migrate();
        }
    }
}

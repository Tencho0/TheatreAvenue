using System.Threading.Tasks;
using TheatreAvenue.Database;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using static TheatreAvenue.Repositories.BaseRepository;

namespace TheatreAvenue.Repository
{
    // Represents a repository for venues
    public class VenueRepository : EntityBaseRepository<Venue>, IVenueRepository
    {
        // Initializes a new instance of the VenueRepository class
        public VenueRepository(TheatreAvenueDbContext context) : base(context) { }

        // Retrieves a venue by its unique identifier
        public async Task<Venue> GetVenueById(int id)
        {
            var venue = await this.GetSingleVenueById(id);

            return venue;
        }
    }
}

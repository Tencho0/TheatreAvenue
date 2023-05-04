using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheatreAvenue.Database;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using static TheatreAvenue.Repositories.BaseRepository;

namespace TheatreAvenue.Repository
{
    // Implements the ISeatRepository interface and inherits from the EntityBaseRepository class
    public class SeatRepository : EntityBaseRepository<Seat>, ISeatRepository
    {
        public TheatreAvenueDbContext _context;

        // Constructor that takes a TheatreAvenueDbContext object and passes it to the base constructor
        public SeatRepository(TheatreAvenueDbContext context) : base(context)
        {
            _context = context;
        }

        // Retrieves a seat with the specified ID
        public async Task<Seat> GetSeatById(int id)
        {
            var seat = await this.GetSingleSeatById(id);

            return seat;
        }

        // Retrieves all seats
        public async Task<List<Seat>> GetAllSeats()
        {
            var seats = await this.GetAllSeatsAsync();

            return seats;
        }

        // Updates a seat
        public async Task UpdateAsync(Seat seat)
        {
            await this.Update(seat);
        }

        // Saves changes to the database
        public void CommitChanges()
        {
            this.Commit();
        }
    }
}


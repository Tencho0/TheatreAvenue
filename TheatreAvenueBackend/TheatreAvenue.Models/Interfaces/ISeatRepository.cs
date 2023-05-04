using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface ISeatRepository
    {
        // Retrieves a single seat by its ID
        Task<Seat> GetSeatById(int id);

        // Retrieves all seats
        Task<List<Seat>> GetAllSeats();

        // Updates a seat asynchronously
        Task UpdateAsync(Seat seat);

        // Commits any changes made to the repository
        void CommitChanges();
    }
}


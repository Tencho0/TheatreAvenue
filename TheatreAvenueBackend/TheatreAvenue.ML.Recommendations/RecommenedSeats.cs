using Microsoft.EntityFrameworkCore;
using TheatreAvenue.Database;
using TheatreAvenue.ML.Recommendations.Interfaces;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.ML.Recommendations
{
    public class RecommenedSeats : IReccomenedSeats
    {
        private TheatreAvenueDbContext _context;

        public RecommenedSeats(TheatreAvenueDbContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetReccomendedSeats(int userId)
        {
            List<Seat> userBookedSeats = _context.Seats
                .Include(s => s.User)
                .Where(s => s.Booked && s.UserId == userId)
                .OrderBy(_ => Guid.NewGuid())
                .Take(3)
                .ToList();

            List<int> userBookedSeatsNumbers = userBookedSeats
                .Select(e => e.Number)
                .ToList();

            // Check if the userBookedSeatsNumbers has less than 3 items
            int missingSeats = 3 - userBookedSeatsNumbers.Count;

            if (missingSeats > 0)
            {
                // List of extra seat numbers
                List<int> extraSeatNumbers = new List<int> { 29, 30, 31 };

                // Add the missing seat numbers
                for (int i = 0; i < missingSeats; i++)
                {
                    userBookedSeatsNumbers.Add(extraSeatNumbers[i]);
                }
            }

            return userBookedSeatsNumbers;
        }
    }
}
using TheatreAvenue.Database;
using TheatreAvenue.ML.Recommendations.Interfaces;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.ML.Recommendations
{
    public class RecommenedTheatres : IReccomenedTheatres
    {
        private TheatreAvenueDbContext _context;

        public RecommenedTheatres(TheatreAvenueDbContext context)
        {
            _context = context;
        }

        public async Task<List<TheatreEvent>> GetReccomendedTheatres(string userGenrePreferences)
        {
            List<string> userGenrePreferencesList = userGenrePreferences.Split(" ").ToList();
            
            List<TheatreEvent> randomTopThreeTheatreEvents = _context.TheatreEvents
                .Where(te => userGenrePreferencesList
                .Contains(te.Genre))
                .OrderBy(_ => Guid.NewGuid())
                .Take(3)
                .ToList();

            return randomTopThreeTheatreEvents;
        }
    }
}
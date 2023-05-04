using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.ML.Recommendations.Interfaces
{
    public interface IReccomenedTheatres
    {
        Task<List<TheatreEvent>> GetReccomendedTheatres(string userGenrePreferences);
    }
}

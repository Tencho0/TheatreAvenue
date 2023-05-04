using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.ML.Recommendations.Interfaces
{
    public interface IReccomenedSeats
    {
        Task<List<int>> GetReccomendedSeats(int userId);
    }
}

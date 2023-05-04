using System.Threading.Tasks;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface IVenueRepository
    {
        Task<Venue> GetVenueById(int id);
    }
}

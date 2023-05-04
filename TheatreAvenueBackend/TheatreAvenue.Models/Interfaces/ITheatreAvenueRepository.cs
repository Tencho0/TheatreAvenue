using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.ViewModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface ITheatreAvenueRepository
    {
        Task<TheatreEvent> GetTheatreEventById(int id);

        Task<TheatreEvent> GetTheatreEventByIdNoAdditionalData(int id);

        Task<TheatreEvent> GetTheatreEventByName(string name);

        Task<List<TheatreEvent>> GetAllTheatreEventsList();

        Task AddAsync(TheatreEventViewModel theatreEventViewModel);
            
        Task UpdateAsync(TheatreEvent theatreEvent);
        
        void CommitChanges();
    }
}

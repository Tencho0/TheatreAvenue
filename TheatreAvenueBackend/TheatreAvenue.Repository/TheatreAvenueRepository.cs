using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreAvenue.Database;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;
using static TheatreAvenue.Repositories.BaseRepository;

namespace TheatreAvenue.Repository
{
    public class TheatreAvenueRepository : EntityBaseRepository<TheatreEvent>, ITheatreAvenueRepository
    {
        public TheatreAvenueRepository(TheatreAvenueDbContext context) : base(context) { }

        // Returns a list of all theatre events in the database
        public async Task<List<TheatreEvent>> GetAllTheatreEventsList()
        {
            var theatreEventsList = await this.GetAllTheatreEventsFromDb();

            return theatreEventsList;
        }

        // Returns a single theatre event by its ID
        public async Task<TheatreEvent> GetTheatreEventById(int id)
        {
            var theatreEvent = await this.GetSingleTheatreEventById(id);

            return theatreEvent;
        }

        // Returns a single theatre event by its name
        public async Task<TheatreEvent> GetTheatreEventByName(string name)
        {
            var theatreEvent = await this.GetSingleTheatreEventByName(name);

            return theatreEvent;
        }

        // Adds a new theatre event to the database
        public async Task AddAsync(TheatreEventViewModel theatreEventViewModel)
        {
            var theatreEvent = new TheatreEvent()
            {
                Description = theatreEventViewModel.Description,
                Venue = theatreEventViewModel.Venue,
                Name = theatreEventViewModel.Name,
                Genre = theatreEventViewModel.Genre,
                Image = theatreEventViewModel.Image,
                Actors = theatreEventViewModel.Actors,
                StartTime = theatreEventViewModel.StartTime,
                TicketPrice = theatreEventViewModel.TicketPrice
            };

            await this.Add(theatreEvent);
        }

        // Updates a theatre event in the database
        public async Task UpdateAsync(TheatreEvent theatreEvent)
        {
            await this.Update(theatreEvent);
        }

        // Commits changes to the database
        public void CommitChanges()
        {
            this.Commit();
        }
    }
}

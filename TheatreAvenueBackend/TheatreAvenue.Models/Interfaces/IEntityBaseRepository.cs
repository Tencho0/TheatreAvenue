using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<List<T>> GetAll();

        int Count();

        Task<User> GetSingleUserByUniqueToken(string token);

        Task<User> GetSingleUserByEmail(string token);

        Task<User> GetSingleUserById(int id);
        
        Task<TheatreEvent> GetSingleTheatreEventByName(string name);

        Task<TheatreEvent> GetSingleTheatreEventById(int id);

        Task<Venue> GetSingleVenueById(int id);
        
        Task<Seat> GetSingleSeatById(int id);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        void Commit();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheatreAvenue.Database;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Repositories
{
    public class BaseRepository
    {
        // Generic repository for entity classes implementing IEntityBase
        public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
        {
            private TheatreAvenueDbContext _context;

            // Constructor with dependency injection for DbContext
            public EntityBaseRepository(TheatreAvenueDbContext context)
            {
                _context = context;
            }

            // Returns a list of all Users from the database with their Preferences and BookedTheatreEvents
            public async Task<List<User>> GetAllUsersFromDb()
            {
                return await _context.Users
                    .ToListAsync();
            }

            // Returns a single User with the specified Id from the database with their Preferences and BookedTheatreEvents
            public async Task<User> GetSingleUserById(int id)
            {
                return await _context
                    .Users
                    .FirstOrDefaultAsync(u => u.Id == id);
            }

            // Returns a single User with the specified UniqueToken from the database with their Preferences and BookedTheatreEvents
            public async Task<User> GetSingleUserByUniqueToken(string token)
            {
                return await _context.Users
                    .FirstOrDefaultAsync(u => u.UniqueToken == token);
            }

            // Returns a single User with the specified email from the database with their Preferences and BookedTheatreEvents
            public async Task<User> GetSingleUserByEmail(string email)
            {
                return await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email);
            }

            // Returns a list of all TheatreEvents from the database
            public async Task<List<TheatreEvent>> GetAllTheatreEventsFromDb()
            {
                return await _context.TheatreEvents
                     .Include(the => the.Venue)
                        .ThenInclude(v => v.Location)
                     .Include(the => the.Venue)
                        .ThenInclude(v => v.Seats)
                    .ToListAsync();
            }

            // Returns a single TheatreEvent with the specified name from the database with its Venue, Seats, and Users who booked seats
            public async Task<TheatreEvent> GetSingleTheatreEventByName(string name)
            {
                return await _context.TheatreEvents
                    .Include(the => the.Venue)
                    .ThenInclude(v => v.Seats)
                    .ThenInclude(v => v.User)
                    .FirstOrDefaultAsync(u => u.Name == name);
            }

            // Returns a single TheatreEvent with the specified Id from the database with its Venue, Location, Seats, and Users who booked seats
            public async Task<TheatreEvent> GetSingleTheatreEventById(int id)
            {
                return await _context.TheatreEvents
                    .Include(the => the.Venue)
                        .ThenInclude(v => v.Location)
                    .Include(the => the.Venue)
                        .ThenInclude(v => v.Seats)
                        .ThenInclude(v => v.User)
                    .FirstOrDefaultAsync(u => u.Id == id);
            }

            // Returns a single TheatreEvent with the specified Id from the database without its related data
            public async Task<TheatreEvent> GetTheatreEventByIdNoAdditionalData(int id)
            {
                return await _context.TheatreEvents
                    .FirstOrDefaultAsync(u => u.Id == id);
            }

            // Returns a single Venue with the specified Id from the database with its Seats and Users who booked seats
            public async Task<Venue> GetSingleVenueById(int id)
            {
                return await _context.Venues
                    .Include(v => v.Seats)
                    .ThenInclude(v => v.User)
                    .FirstOrDefaultAsync(v => v.Id == id);
            }

            // Seats 
            public async Task<Seat> GetSingleSeatById(int id)
            {
                return await _context.Seats
                    .Include(v => v.User) // Include User navigation property
                    .FirstOrDefaultAsync(v => v.Id == id);
            }

            public async Task<List<Seat>> GetAllSeatsAsync()
            {
                return await _context.Seats.ToListAsync(); // Get all seats from the database
            }

            public virtual async Task<List<T>> GetAll()
            {
                return await _context.Set<T>().ToListAsync(); // Get all entities of type T from the database
            }

            public virtual int Count()
            {
                return _context.Set<T>().Count(); // Get the count of entities of type T from the database
            }

            public virtual async Task Add(T entity)
            {
                _context.Set<T>().Add(entity); // Add a new entity of type T to the database
            }

            public virtual async Task Update(T entity)
            {
                EntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Modified; // Update an existing entity of type T in the database
            }

            public virtual async Task Delete(T entity)
            {
                EntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Deleted; // Delete an existing entity of type T from the database
            }

            public virtual void Commit()
            {
                _context.SaveChanges(); // Save changes to the database
            }
        }
    }
}

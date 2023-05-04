using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreAvenue.Database;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;

namespace TheatreAvenue.Repository
{
    public class UserRepository : Repositories.BaseRepository.EntityBaseRepository<User>, IUserRepository
    {
        IAuthService _authService;

        // Constructor to inject an instance of IAuthService and TheatreAvenueDbContext
        public UserRepository(IAuthService authService, TheatreAvenueDbContext context) : base(context)
        {
            _authService = authService;
        }

        // Checks if email is unique in the database
        public async Task<bool> IsEmailUniq(string email)
        {
            var user = await this.GetSingleUserByEmail(email);

            return user == null;
        }

        // Retrieves a user by their ID
        public async Task<User> GetUserById(int id)
        {
            var user = await this.GetSingleUserById(id);

            return user;
        }

        // Retrieves a user by their email
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await this.GetSingleUserByEmail(email);

            return user;
        }

        // Adds a new user to the database
        public async Task AddAsync(UserViewModel user, string password)
        {
            // Hashes the provided password before adding it to the database
            User newUser = new User()
            {
                Email = user.Email,
                Name = user.Name,
                SureName = user.SureName,
                Password = _authService.HashPassword(password),
                UniqueToken = user.UniqueToken,
                IsAdmin = user.IsAdmin,
                BookedTheatreEventsIds = "",
                Preferences = user.Preferences
            };

            await this.Add(newUser);
        }

        // Updates an existing user in the database
        public async Task UpdateAsync(User user)
        {
            await this.Update(user);
        }

        // Commits changes to the database
        public void CommitChanges()
        {
            this.Commit();
        }
    }
}

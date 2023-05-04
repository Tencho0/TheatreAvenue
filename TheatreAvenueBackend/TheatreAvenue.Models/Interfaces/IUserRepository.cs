using System.Threading.Tasks;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.ViewModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsEmailUniq(string email);
        
        Task<User> GetUserById(int id);

        Task<User> GetUserByEmail(string email);

        Task AddAsync(UserViewModel user, string password);

        Task UpdateAsync(User user);

        void CommitChanges();
    }
}

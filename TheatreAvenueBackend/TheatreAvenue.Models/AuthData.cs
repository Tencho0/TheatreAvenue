using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models
{
    //ViewModel the user will receive after authentication
    public class AuthData : IAuthData
    {
        public string Token { get; set; } // The JWT token that will be used for authorization

        public long TokenExpirationTime { get; set; } // The time when the token will expire (in Unix timestamp format)

        public string UniqueToken { get; set; } // A unique identifier for the user
    }
}

namespace TheatreAvenue.Models.Interfaces
{
    // Interface for representing the authentication data
    public interface IAuthData
    {
        // Property for the token string
        string Token { get; set; }

        // Property for the token expiration time in ticks
        long TokenExpirationTime { get; set; }

        // Property for the unique token string
        string UniqueToken { get; set; }
    }
}

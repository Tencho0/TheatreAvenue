namespace TheatreAvenue.Models.Interfaces
{
    public interface IAuthService
    {
        // Returns the authentication data for a given user ID
        AuthData GetAuthData(string id);

        // Verifies whether the provided password matches the hashed user password
        bool VerifyPassword(string modelPassword, string userPassword);

        // Hashes the provided password using a secure hashing algorithm
        string HashPassword(string password);
    }
}


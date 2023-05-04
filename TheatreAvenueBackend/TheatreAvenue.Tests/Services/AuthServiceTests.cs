using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TheatreAvenue.Services;
using Xunit;

namespace TheatreAvenue.Tests
{
    public class AuthServiceTests
    {
        private readonly string _jwtSecret = "9XqN3CXCPn7Jtt5qxY56CfV2pjPT6k5z6UdAs6u5M6Pv8mU5F42awgkEyrG7yPv8";
        private readonly int _jwtLifespan = 3600;
        private readonly AuthService _service;

        public AuthServiceTests()
        {
            _service = new AuthService(_jwtSecret, _jwtLifespan);
        }

        [Fact]
        public void GetAuthData_ReturnsValidAuthData()
        {
            // Arrange
            var uniqueToken = "test_unique_token";
            var expectedExpirationTime = DateTime.UtcNow.AddSeconds(_jwtLifespan);

            var service = new AuthService(_jwtSecret, _jwtLifespan);

            // Act
            var result = service.GetAuthData(uniqueToken);

            // Assert
            Assert.NotNull(result.Token);
            Assert.Equal(uniqueToken, result.UniqueToken);
            Assert.Equal(((DateTimeOffset)expectedExpirationTime).ToUnixTimeSeconds(), result.TokenExpirationTime);

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(result.Token);
            Assert.NotNull(jwt);
            Assert.Equal(expectedExpirationTime.ToString("yyyy-MM-dd HH:mm:ss"), jwt.ValidTo.ToString("yyyy-MM-dd HH:mm:ss"));
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
            var expectedSignature = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
            Assert.Equal(expectedSignature.Algorithm, "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");
        }


        [Fact]
        public void HashPassword_ReturnsHashedPassword()
        {
            // Arrange
            var password = "test_password";

            // Act
            var hashedPassword = _service.HashPassword(password);

            // Assert
            Assert.NotNull(hashedPassword);
            Assert.NotEqual(password, hashedPassword);
        }

        [Fact]
        public void VerifyPassword_ReturnsTrueForValidPassword()
        {
            // Arrange
            var password = "test_password";
            var hashedPassword = _service.HashPassword(password);

            // Act
            var result = _service.VerifyPassword(password, hashedPassword);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerifyPassword_ReturnsFalseForInvalidPassword()
        {
            // Arrange
            var password = "test_password";
            var hashedPassword = _service.HashPassword(password);

            // Act
            var result = _service.VerifyPassword("invalid_password", hashedPassword);

            // Assert
            Assert.False(result);
        }
    }
}

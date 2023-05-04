﻿using CryptoHelper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheatreAvenue.Models;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Services
{
    //Service which generates JWT tokens
    public class AuthService : IAuthService
    {
        string jwtSecret;

        int jwtLifespan;

        public AuthService(string jwtSecret, int jwtLifespan)
        {
            this.jwtSecret = jwtSecret;

            this.jwtLifespan = jwtLifespan;
        }

        //Create the authentication data with a signed token
        public AuthData GetAuthData(string uniqueToken)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, uniqueToken)
                }),
                Expires = expirationTime,
                // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthData
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                UniqueToken = uniqueToken
            };
        }

        //Hash a plaintext password using the CryptoHelper library
        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        //Verify a plaintext password against a hashed password using the CryptoHelper library
        public bool VerifyPassword(string actualPassword, string hashedPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, actualPassword);
        }
    }
}

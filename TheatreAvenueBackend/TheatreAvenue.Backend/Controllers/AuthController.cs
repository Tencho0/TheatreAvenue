using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreAvenue.ML.Recommendations.Interfaces;
using TheatreAvenue.Models;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;

//This code defines an API controller for handling authentication related requests.
//The controller uses the injected ILoggerService to log information about user login and registration.
//This controller provides endpoints for user authentication and registration.

namespace TheatreAvenue.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase 
    {
        //The AuthController class is decorated with the[Route] and[ApiController] attributes, 
        //indicating that it is an API controller and specifying the base URL route for its actions.

        private readonly IReccomenedTheatres _reccomenedTheatres;

        private readonly IReccomenedSeats _reccomenedSeats;

        private readonly IAuthService _authService;

        private readonly IUserRepository _userRepository;

        private readonly ILoggerService _logger;

        public AuthController(
            IReccomenedTheatres reccomenedTheatres, 
            IReccomenedSeats reccomenedSeats, 
            IAuthService authService, 
            IUserRepository userRepository, 
            ILoggerService logger)
        {
            _reccomenedTheatres = reccomenedTheatres;

            _reccomenedSeats = reccomenedSeats;

            _authService = authService;

            _userRepository = userRepository;
            
            _logger = logger;
        }

        //The login action accepts a LoginViewModel object as a parameter. 
        //This object is validated against the model state, and an error response is returned if validation fails. 
        //The user is then retrieved from the user repository by their email address. 
        //If no user is found, a bad request response is returned. I
        //If the user is found, their password is validated against the provided password.
        //If the password is invalid, a bad request response is returned.
        //If the password is valid, an authentication token is generated for the user, a UserData object is created, and the user is logged in.
        //A UserDetailsAuthData object is returned with the authentication token and user data.

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            User user = await _userRepository.GetUserByEmail(model.Email);

            if (user == null)
            {
                return BadRequest("No user with this email");
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.Password);

            if (!passwordValid)
            {
                return BadRequest("Invalid password");
            }

            AuthData authData = _authService.GetAuthData(user.UniqueToken);

            var reccomendedTheatreEvents = await _reccomenedTheatres.GetReccomendedTheatres(user.Preferences);

            var reccomendedSeatNumbers = await _reccomenedSeats.GetReccomendedSeats(user.Id);

            UserData userData = new UserData()
            {
                Email = user.Email,

                IsAdmin = user.IsAdmin,

                Preferences = user.Preferences,

                BookedTheatreEventsIds = user.BookedTheatreEventsIds,

                ReccomendedTheatreEvents = reccomendedTheatreEvents,

                ReccomendedSeatNumbers = reccomendedSeatNumbers
            };

            _logger.LogInfo($"User {user.Email} logged in.");

            var result = new UserDetailsAuthData() { AuthData = authData, UserData = userData };

            return Ok(result);
        }

        //The register action accepts a RegisterViewModel object as a parameter.
        //This object is validated against the model state, and an error response is returned if validation fails.
        //The user's email address is checked to see if it is unique in the user repository.
        //If it is not unique, a bad request response is returned.
        //If the email address is unique, a new UserViewModel object is created with the provided user details and password.
        //The user is then added to the user repository, a new authentication token is generated for the user,
        //a UserData object is created, and the user is registered.
        //A UserDetailsAuthData object is returned with the authentication token and user data.

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var emailUniq = await _userRepository.IsEmailUniq(model.Email);

            if (!emailUniq) return BadRequest("User with this email already exists");
            
            var uniqueToken = Guid.NewGuid().ToString();

            var user = new UserViewModel
            {
                UniqueToken = uniqueToken,
                Email = model.Email,
                Name = model.Name,
                SureName = model.SureName,
                BookedTheatreEventsIds = "",
                Preferences = model.GenrePreferences,
                IsAdmin = model.IsAdmin
            };

            await _userRepository.AddAsync(user, model.Password);

            _userRepository.CommitChanges();

            AuthData authData = _authService.GetAuthData(user.UniqueToken);

            var reccomendedTheatreEvents = await _reccomenedTheatres.GetReccomendedTheatres(user.Preferences);

            UserData userData = new UserData()
            {
                Email = user.Email,
                Preferences = user.Preferences,
                BookedTheatreEventsIds = "",
                IsAdmin = user.IsAdmin,
                ReccomendedTheatreEvents = reccomendedTheatreEvents,
                ReccomendedSeatNumbers = new List<int>() { 29, 30, 31 }
            };

            _logger.LogInfo($"User {user.Email} registered.");

            var result = new UserDetailsAuthData() { AuthData = authData, UserData = userData };

            return Ok(result); //The controller actions return IActionResult objects, which can be of various types such as BadRequest, Ok, etc.
        }
    }
}

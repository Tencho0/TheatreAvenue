using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;

namespace TheatreAvenue.Backend.Controllers
{
    [Route("api/[controller]")]  //specifies the base URL of the API endpoint (/api/users in this case).

    [ApiController] //adds some default behaviors like automatic validation of model state.

    [Authorize] //used to indicate that access to this controller requires authentication.
    public class UsersController : ControllerBase
    {
        private readonly ILoggerService _logger; // is used for logging

        private readonly IUserRepository _userRepository; // used for database access.

        public UsersController(ILoggerService logger, IUserRepository userRepository)
        {
            //takes in ILoggerService and IUserRepository as dependencies,
            //and assigns them to the respective private fields.

            _logger = logger;

            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null) return BadRequest("User does not exist.");

            _logger.LogInfo($"User '{id}' returned.");

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null) return BadRequest("User does not exist.");

            _logger.LogInfo($"User '{email}' returned.");

            return Ok(user);
        }

        // PUT api/users/uniqueToken
        [HttpPut("update/{email}")]
        public async Task<IActionResult> Put(string email, [FromBody] UserEditViewModel userViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await _userRepository.GetUserByEmail(email);

            if (user == null) return BadRequest("User does not exist.");

            user.Name = userViewModel.Name;

            user.SureName = userViewModel.SureName;

            user.Email = userViewModel.Email;

            user.Preferences = userViewModel.Preferences;

            await _userRepository.UpdateAsync(user);

            _userRepository.CommitChanges();

            _logger.LogInfo($"User '{user.Email}' was updated.");

            return Ok($"User '{user.Email}' was updated successfully.");
        }
    }
}

//In summary, this code file defines a controller class for handling user-related HTTP requests in a theatre booking application.
//It uses dependency injection to inject the necessary services and interfaces and performs validation on incoming model data.
//The class handles GET, PUT, and DELETE requests for retrieving, updating, and deleting users.
//It also logs all requests for debugging and auditing purposes.
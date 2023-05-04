using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Backend.Controllers
{
    [Route("api/[controller]")] //sets the base route for the controller to /api/venue,
                                //where venue is the name of the controller class
    [ApiController] //enables some common web API behaviors,
                    //such as automatic model validation and response formatting. 
    [Authorize] //specifies that any requests to this controller require authorization.
    public class VenueController : ControllerBase
    {
        //These are used to log information about the controller's actions
        //and to perform CRUD operations on the Venue objects in the database.

        private readonly ILoggerService _logger;

        private readonly IVenueRepository _venueRepository;

        public VenueController(ILoggerService logger, IVenueRepository venueRepository)
        {
            _logger = logger;

            _venueRepository = venueRepository;
        }

        //The Get method accepts a venue ID as a parameter,
        //retrieves the corresponding venue from the repository,
        //logs information about the retrieval,
        //and returns the venue as an OkObjectResult.
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var venue = await _venueRepository.GetVenueById(id);

            if (venue == null) return BadRequest("Venue does not exist.");

            _logger.LogInfo($"Venue '{id}' returned.");

            return Ok(venue);
        }
    }
}

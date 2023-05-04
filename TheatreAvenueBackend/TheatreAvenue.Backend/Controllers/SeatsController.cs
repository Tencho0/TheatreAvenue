using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This attribute requires authorization for all methods in the controller
    public class SeatsController : ControllerBase
    {
        private readonly ILoggerService _logger;

        private readonly ISeatRepository _seatRepository;

        public SeatsController(ILoggerService logger, ISeatRepository seatRepository)
        {
            _logger = logger; // Logger service for logging information about the controller
            _seatRepository = seatRepository; // Repository for retrieving information about seats
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) // Endpoint for retrieving a seat by ID
        {
            var seat = await _seatRepository.GetSeatById(id); // Retrieves the seat from the repository

            if (seat == null) return BadRequest("Seat does not exist."); // If the seat does not exist, return a bad request status with a message

            _logger.LogInfo($"Seat '{id}' returned."); // Log that the seat was returned successfully

            return Ok(seat); // Return the seat object with a 200 OK status
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get() // Endpoint for retrieving all seats
        {
            var seats = await _seatRepository.GetAllSeats(); // Retrieves all seats from the repository

            _logger.LogInfo($"All Seats are returned."); // Log that all seats were returned successfully

            return Ok(seats); // Return the seats collection with a 200 OK status
        }
    }
}

//The code defines a SeatsController that handles HTTP GET requests for retrieving information about seats. 
//The controller has two endpoints: Get(int id) for retrieving a seat by ID and Get() for retrieving all seats.

//The[Authorize] attribute requires authorization for all methods in the controller. 
//The constructor of the controller takes two parameters: an ILoggerService instance for logging information about the controller and an ISeatRepository instance for retrieving information about seats.

//In the Get(int id) endpoint, the GetSeatById method of the repository is used to retrieve the seat by ID. 
//If the seat does not exist, a bad request status with a message is returned. If the seat exists, it is returned with a 200 OK status and the ID of the seat is logged.

//In the Get() endpoint, the GetAllSeats method of the repository is used to retrieve all seats. 
//The seats collection is returned with a 200 OK status and a log message is written to indicate that all seats were returned successfully.
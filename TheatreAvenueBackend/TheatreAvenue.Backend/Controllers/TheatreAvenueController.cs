using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheatreAvenue.ML.Recommendations.Interfaces;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;

// Defining the namespace for the controller
namespace TheatreAvenue.Backend.Controllers
{
    // Defining the route prefix for the controller
    [Route("api/[controller]")]
    // Specifying that the controller is an API controller
    [ApiController]
    // Specifying that authorization is required to access the controller
    [Authorize]
    // Defining the controller class
    public class TheatreAvenueController : ControllerBase
    {
        // Injecting logger service and repositories into the controller
        private readonly ILoggerService _logger;
        private readonly ITheatreAvenueRepository _theatreAvenueRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISeatRepository _seatRepository;

        private readonly IReccomenedTheatres _reccomenedTheatres;

        private readonly IReccomenedSeats _reccomenedSeats;

        public TheatreAvenueController(ILoggerService logger, 
            ITheatreAvenueRepository theatreAvenueRepository, 
            IUserRepository userRepository, 
            ISeatRepository seatRepository,
            IReccomenedTheatres reccomenedTheatres,
            IReccomenedSeats reccomenedSeats)
        {
            // Initializing logger service and repositories
            _logger = logger;
            _theatreAvenueRepository = theatreAvenueRepository;
            _userRepository = userRepository;
            _seatRepository = seatRepository;

            _reccomenedTheatres = reccomenedTheatres;

            _reccomenedSeats = reccomenedSeats;
        }

        // Defining a GET method to return all theatre events
        [HttpGet("all")]
        public async Task<IActionResult> Get(string email, string reccomendedTheatreNames)
        {
            List<string> reccomendedTheatreNamesList = reccomendedTheatreNames.Split("|").ToList();

            User userFromDb = await _userRepository.GetUserByEmail(email);

            List<string> userPreferences = userFromDb.Preferences.Split(" ").ToList();

            // Getting all theatre events from the database
            List<TheatreEvent> theatreEventsFromDb = await _theatreAvenueRepository.GetAllTheatreEventsList();
            

            // Getting the current datetime
            var now = DateTime.Now;

            // Looping through each theatre event and checking if it has already started
            foreach (var theatreEvent in theatreEventsFromDb)
            {
                if (theatreEvent.StartTime < now)
                {
                    // If the event has already started, adding a random number of days to the start time
                    Random random = new Random();
                    int randomNumber = random.Next(1, 31);
                    theatreEvent.StartTime = now.AddDays(randomNumber);

                    // Updating the event in the database
                    await _theatreAvenueRepository.UpdateAsync(theatreEvent);

                    // Committing the changes to the database
                    _theatreAvenueRepository.CommitChanges();
                }
            }

            // Sorting the theatre events by start time
            //var sortedTheatreEvents = theatreEventsFromDb.OrderBy(te => te.StartTime);

            var orderedTheatreEvents = theatreEventsFromDb
                .OrderByDescending(the => userPreferences.Contains(the.Genre))
                .ThenByDescending(th => th.Name == reccomendedTheatreNamesList[0])
                .ThenByDescending(th => th.Name == reccomendedTheatreNamesList[1])
                .ThenByDescending(th => th.Name == reccomendedTheatreNamesList[2]);
                

            // Logging that all theatre events are returned
            _logger.LogInfo($"All Theatre Events are returned.");

            // Returning the sorted theatre events
            return Ok(orderedTheatreEvents);
        }

        // Defining a GET method to return a specific theatre event by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Getting the theatre event with the specified ID from the database
            var theatreAvenue = await _theatreAvenueRepository.GetTheatreEventById(id);

            // Returning an error if the theatre event does not exist
            if (theatreAvenue == null) return BadRequest("Theatre Event does not exist.");

            // Logging that the theatre event is returned
            _logger.LogInfo($"Theatre Event '{id}' returned.");

            // Returning the theatre event
            return Ok(theatreAvenue);
        }

        // Defining a POST method to book a theatre event
        [HttpPost("BookEvent")]
        public async Task<IActionResult> Post([FromBody] BookTheatreEvent bookTheatreEvent)
        {
            // Checking if the model state is valid
            if (!ModelState.IsValid) return BadRequest();

            // Getting the user from the database using the provided email
            User userFromDb = await _userRepository.GetUserByEmail(bookTheatreEvent.UserEmail);

            TheatreEvent bookerTheatreEvent = await _theatreAvenueRepository.GetTheatreEventById(bookTheatreEvent.TheatreEventId);

            var userHasAlreadyBookedTheTheatreEvent = userFromDb.BookedTheatreEventsIds.Contains(bookerTheatreEvent.Name);            

            if (!userHasAlreadyBookedTheTheatreEvent)
            {
                userFromDb.BookedTheatreEventsIds += $"|{bookerTheatreEvent.Name}";

                // Updating the user's data in the database
                await _userRepository.UpdateAsync(userFromDb);

                // Committing the changes to the database
                _userRepository.CommitChanges();

                // Logging that the theatre event was added to the user's booked events
                _logger.LogInfo($"Theatre Event added to the user Booked Theatre Events.");
            }
            // Updating the status of the selected seats in the venue for the theatre event
            foreach (var seat in bookTheatreEvent.SelectedSeats)
            {
                // Parsing the seat number from the seat string
                var seatNumber = int.Parse(seat.Split(" ")[1]);

                var seatObj = bookerTheatreEvent.Venue.Seats.FirstOrDefault(s => s.Number == seatNumber);

                // Setting the seat to booked
                seatObj!.Booked = true;

                // Assigning the user ID to the seat
                seatObj.UserId = userFromDb.Id;

                // Updating the seat object in the database
                await _seatRepository.UpdateAsync(seatObj);

                // Committing the changes to the database
                _seatRepository.CommitChanges();
            }
            // Logging that the user has been added to each seat and the seat status has been set to booked
            _logger.LogInfo($"The user is added to each Seat. Seat was set to booked.");

            List<int> reccomendedSeatNumbers = await _reccomenedSeats.GetReccomendedSeats(userFromDb.Id);

            BoockedTheatreEventResponseData boockedTheatreEventResponseData = new BoockedTheatreEventResponseData(bookerTheatreEvent, reccomendedSeatNumbers);
            
            return Ok(boockedTheatreEventResponseData);
        }
    }
}

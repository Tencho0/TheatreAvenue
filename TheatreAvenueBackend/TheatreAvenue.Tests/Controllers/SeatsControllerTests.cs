using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreAvenue.Backend.Controllers;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using Xunit;

namespace TheatreAvenue.Tests.Backend.Controllers
{
    // This constructor initializes the private fields and creates an instance of the SeatsController class.
    public class SeatsControllerTests
    {
        private readonly Mock<ILoggerService> _loggerMock;
        private readonly Mock<ISeatRepository> _seatRepositoryMock;
        private readonly SeatsController _controller;

        public SeatsControllerTests()
        {
            _loggerMock = new Mock<ILoggerService>();
            _seatRepositoryMock = new Mock<ISeatRepository>();
            _controller = new SeatsController(_loggerMock.Object, _seatRepositoryMock.Object);
        }

        // This test checks if the Get method returns an OkObjectResult when a seat with the specified id exists.
        [Fact]
        public async Task Get_ReturnsOkObjectResult_WhenSeatExists()
        {
            // Arrange
            int id = 1;
            var seat = new Seat() { Id = id };
            _seatRepositoryMock.Setup(repo => repo.GetSeatById(id)).ReturnsAsync(seat);

            // Act
            var result = await _controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(seat, okResult.Value);
        }

        // This test checks if the Get method returns a BadRequestObjectResult when a seat with the specified id does not exist.
        [Fact]
        public async Task Get_ReturnsBadRequestObjectResult_WhenSeatDoesNotExist()
        {
            // Arrange
            int id = 1;
            Seat seat = null;
            _seatRepositoryMock.Setup(repo => repo.GetSeatById(id)).ReturnsAsync(seat);

            // Act
            var result = await _controller.Get(id);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal("Seat does not exist.", badRequestResult.Value);
        }

        // This test checks if the Get method returns an OkObjectResult when seats exist in the repository.
        [Fact]
        public async Task GetAll_ReturnsOkObjectResult_WhenSeatsExist()
        {
            // Arrange
            List<Seat> seats = new List<Seat>() { new Seat()
            {
                Id = 1,
                Booked = true,
                Number = 10,
                Row = 1,
                UserId = 2
            }};
            _seatRepositoryMock.Setup(repo => repo.GetAllSeats()).ReturnsAsync(seats);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(seats, okResult.Value);
        }

        // This test checks if the Get method returns an OkObjectResult with an empty list when no seats exist in the repository.
        [Fact]
        public async Task GetAll_ReturnsOkObjectResult_WhenNoSeatsExist()
        {
            // Arrange
            List<Seat> seats = new List<Seat>();

            _seatRepositoryMock.Setup(repo => repo.GetAllSeats()).ReturnsAsync(seats);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Empty((List<Seat>)okResult.Value);
        }
    }
}

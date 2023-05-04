using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TheatreAvenue.Backend.Controllers;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using Xunit;

namespace TheatreAvenue.Tests.Controllers
{
    public class VenueControllerTests
    {
        [Fact]
        public async Task Get_ValidId_ReturnsOkObjectResult()
        {
            // Arrange
            var loggerService = Mock.Of<ILoggerService>();
            var venueRepository = new Mock<IVenueRepository>();
            var controller = new VenueController(loggerService, venueRepository.Object);
            var id = 1;
            var venue = new Venue() { Id = id, Name = "Test Venue" };
            venueRepository.Setup(repo => repo.GetVenueById(id)).ReturnsAsync(venue);

            // Act
            var result = await controller.Get(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Venue>(okResult.Value);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task Get_InvalidId_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var loggerService = Mock.Of<ILoggerService>();
            var venueRepository = new Mock<IVenueRepository>();
            var controller = new VenueController(loggerService, venueRepository.Object);
            var id = -1;
            Venue venue = null;
            venueRepository.Setup(repo => repo.GetVenueById(id)).ReturnsAsync(venue);

            // Act
            var result = await controller.Get(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Venue does not exist.", badRequestResult.Value);
        }
    }
}

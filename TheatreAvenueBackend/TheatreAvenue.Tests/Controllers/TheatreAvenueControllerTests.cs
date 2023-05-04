using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TheatreAvenue.Backend.Controllers;
using TheatreAvenue.ML.Recommendations.Interfaces;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;
using Xunit;

namespace TheatreAvenue.Backend.Tests
{
    public class TheatreAvenueControllerTests
    {
        private readonly Mock<ILoggerService> _loggerMock;
        private readonly Mock<ITheatreAvenueRepository> _theatreAvenueRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<ISeatRepository> _seatRepositoryMock;
        private readonly Mock<IReccomenedTheatres> _reccomenedTheatresMock;
        private readonly Mock<IReccomenedSeats> _reccomenedSeatsMock;
        private readonly TheatreAvenueController _controller;

        public TheatreAvenueControllerTests()
        {
            _loggerMock = new Mock<ILoggerService>();
            _theatreAvenueRepositoryMock = new Mock<ITheatreAvenueRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _seatRepositoryMock = new Mock<ISeatRepository>();
            _reccomenedTheatresMock = new Mock<IReccomenedTheatres>();
            _reccomenedSeatsMock = new Mock<IReccomenedSeats>();
            _controller = new TheatreAvenueController(_loggerMock.Object, _theatreAvenueRepositoryMock.Object,
                _userRepositoryMock.Object, _seatRepositoryMock.Object, _reccomenedTheatresMock.Object, _reccomenedSeatsMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsAllTheatreEvents()
        {
            // Arrange
            var email = "atanasskambitovv@gmail.com";
            var expectedTheatreEvents = new List<TheatreEvent>() { new TheatreEvent() {
                Id = 1,
                Name = "Example Name",
                Actors = "Some Actors",
                Description = "Some Description",
                Genre = "Drama",
                Image = "SomeImage",
                StartTime = DateTime.Now,
                TicketPrice = 22.5,
                VenueId = 1,
            } };

            _theatreAvenueRepositoryMock.Setup(repo => repo.GetAllTheatreEventsList())
                .ReturnsAsync(expectedTheatreEvents);

            _userRepositoryMock.Setup(ur => ur.GetUserByEmail(email))
             .ReturnsAsync(new User() { Email = email, Preferences = "Drama" });

            // Act
            var result = await _controller.Get(email, "|The Last Waltz|The Heist|Hamlet");

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedTheatreEvents, okResult.Value);
        }

        [Fact]
        public async Task Get_WithValidId_ReturnsTheatreEvent()
        {
            // Arrange
            var id = 123;
            var expectedTheatreEvent = new TheatreEvent { Id = id };
            _theatreAvenueRepositoryMock.Setup(repo => repo.GetTheatreEventById(id))
                .ReturnsAsync(expectedTheatreEvent);

            // Act
            var result = await _controller.Get(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(expectedTheatreEvent, okResult.Value);
        }

        [Fact]
        public async Task Get_WithInvalidId_ReturnsBadRequest()
        {
            // Arrange
            var id = 123;
            _theatreAvenueRepositoryMock.Setup(repo => repo.GetTheatreEventById(id))
                .ReturnsAsync(null as TheatreEvent);

            // Act
            var result = await _controller.Get(id);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal("Theatre Event does not exist.", badRequestResult.Value);
        }

        [Fact]
        public async Task Post_WithInvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            var bookTheatreEvent = new BookTheatreEvent();
            _controller.ModelState.AddModelError("UserEmail", "The UserEmail field is required.");

            // Act
            var result = await _controller.Post(bookTheatreEvent);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Post_WithNewBooking_ReturnsOkResult()
        {
            // Arrange
            var bookTheatreEvent = new BookTheatreEvent
            {
                UserEmail = "test@example.com",
                TheatreEventId = 123,
                SelectedSeats = new List<string>() { "Seat 1", "Seat 2" }
            };

            var user = new User { Id = 1, BookedTheatreEventsIds = "" };

            var theatreEvent = new TheatreEvent
            {
                Id = bookTheatreEvent.TheatreEventId,
                Name = "Test Event",
                Venue = new Venue
                {
                    Seats = new List<Seat>()
                    {
                        new Seat { Number = 1 },
                        new Seat { Number = 2 }
                    }
                }
            };
            _userRepositoryMock.Setup(repo => repo.GetUserByEmail(bookTheatreEvent.UserEmail))
                .ReturnsAsync(user);
            _theatreAvenueRepositoryMock.Setup(repo => repo.GetTheatreEventById(bookTheatreEvent.TheatreEventId))
                .ReturnsAsync(theatreEvent);
            _seatRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Seat>()))
                .Returns(Task.CompletedTask);
            _userRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Post(bookTheatreEvent);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;

            // Verify user and seat repositories were called correctly
            _userRepositoryMock.Verify(repo => repo.GetUserByEmail(bookTheatreEvent.UserEmail), Times.Once);
            _userRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<User>()), Times.Once);
            _seatRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Seat>()), Times.Exactly(2));
            _seatRepositoryMock.Verify(repo => repo.CommitChanges(), Times.Exactly(2));
        }
    }
}
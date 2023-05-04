using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TheatreAvenue.Backend.Controllers;
using TheatreAvenue.ML.Recommendations.Interfaces;
using TheatreAvenue.Models;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;
using Xunit;

// This namespace contains the tests for the AuthController class.
namespace TheatreAvenue.Tests.Controllers
{
    // This class contains tests for the AuthController class.
    public class AuthControllerTests
    {
        // The controller instance that is being tested.
        private readonly AuthController _controller;

        // Mocks of the dependencies of the controller.
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IReccomenedTheatres> _reccomenedTheatres;
        private readonly Mock<IReccomenedSeats> _reccomenedSeats;
        private readonly Mock<ITheatreAvenueRepository> _theatreAvenueRepositoryMock;
        private readonly Mock<ILoggerService> _loggerMock;

        // Constructor that sets up the mocks and the controller instance.
        public AuthControllerTests()
        {
            // Set up the mock dependencies.
            _authServiceMock = new Mock<IAuthService>();
            _userRepository = new Mock<IUserRepository>();
            _reccomenedTheatres = new Mock<IReccomenedTheatres>();
            _reccomenedSeats = new Mock<IReccomenedSeats>();
            _theatreAvenueRepositoryMock = new Mock<ITheatreAvenueRepository>();
            _loggerMock = new Mock<ILoggerService>();

            // Create the controller instance.
            _controller = new AuthController(
                _reccomenedTheatres.Object,
                _reccomenedSeats.Object,
                _authServiceMock.Object,
                _userRepository.Object,
                _loggerMock.Object
            );
        }

        // Test method that checks if the Post method returns the correct result when given valid credentials.
        [Fact]
        public async Task Post_WithValidCredentials_ReturnsOkObjectResult()
        {
            // Arrange
            // Create a model with valid credentials.
            var model = new LoginViewModel()
            {
                Email = "test@test.com",
                Password = "123456"
            };

            // Create a user with the same email as the model.
            var user = new User()
            {
                UniqueToken = "123",
                Email = model.Email,
                Password = "hashedPassword"
            };

            _userRepository.Setup(x => x.GetUserByEmail(model.Email)).ReturnsAsync(user);

            _authServiceMock.Setup(x => x.VerifyPassword(model.Password, user.Password)).Returns(true);

            var expectedAuthData = new AuthData()
            {
                Token = "testToken",
                TokenExpirationTime = 12345678,
                UniqueToken = user.UniqueToken
            };

            _authServiceMock.Setup(x => x.GetAuthData(user.UniqueToken)).Returns(expectedAuthData);

            var expectedUserData = new UserData()
            {
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                Preferences = user.Preferences,
                BookedTheatreEventsIds = user.BookedTheatreEventsIds
            };

            // Act
            // Call the Post method with the model.
            var result = await _controller.Post(model);

            // Assert
            // Check if the result is an OkObjectResult and if its value matches the expected data.
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultData = Assert.IsType<UserDetailsAuthData>(okResult.Value);
            Assert.Equal(expectedAuthData, resultData.AuthData);
            Assert.Equal(expectedUserData.Email, resultData.UserData.Email);
        }

        // Test method that checks if the Post method returns the correct result when given an invalid password.
        [Fact]
        public async Task Post_WithWrongPassword_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var controller = new AuthController(
                _reccomenedTheatres.Object,
                _reccomenedSeats.Object,
                _authServiceMock.Object,
                _userRepository.Object, 
                _loggerMock.Object);

            var loginViewModel = new LoginViewModel()
            {
                Email = "test@example.com",
                Password = "invalidpassword"
            };
            var user = new User() { Email = "test@example.com", Password = "correctpassword" };
            _userRepository.Setup(x => x.GetUserByEmail(loginViewModel.Email)).ReturnsAsync(user);
            _authServiceMock.Setup(x => x.VerifyPassword(loginViewModel.Password, user.Password)).Returns(false);

            // Act
            var result = await controller.Post(loginViewModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var response = (BadRequestObjectResult)result;
            Assert.Equal("Invalid password", response.Value);
        }

        [Fact]
        public async Task Post_WithNonexistentUser_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var mockUserRepository = new Mock<IUserRepository>();
            var mockSeatsRepository = new Mock<ISeatRepository>();
            var mockTheatreAvenueRepository = new Mock<ITheatreAvenueRepository>();
            var mockLogger = new Mock<ILoggerService>();

            mockUserRepository.Setup(repo => repo.GetUserByEmail(It.IsAny<string>()))
                              .ReturnsAsync((User)null); // return null user

            var controller = new AuthController(
                _reccomenedTheatres.Object,
                _reccomenedSeats.Object,
                _authServiceMock.Object,
                _userRepository.Object,
                _loggerMock.Object);

            var invalidModel = new LoginViewModel
            {
                Email = "nonexistentuser@example.com",
                Password = "password123"
            };

            // Act
            var result = await controller.Post(invalidModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.Equal("No user with this email", badRequestResult.Value);
 
        }


        [Fact]
        public async Task Post_WithInvalidModelState_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var model = new LoginViewModel();

            _controller.ModelState.AddModelError("Email", "Email is required");

            // Act
            var result = await _controller.Post(model);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            Assert.IsType<SerializableError>(badRequestResult.Value);
        }
    }
}
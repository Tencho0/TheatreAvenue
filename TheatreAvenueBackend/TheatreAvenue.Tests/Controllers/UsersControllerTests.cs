using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using TheatreAvenue.Backend.Controllers;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;
using TheatreAvenue.Models.ViewModels;
using Xunit;

namespace TheatreAvenue.Tests.Controllers
{
    public class UsersControllerTests
    {
        private readonly Mock<ILoggerService> _loggerServiceMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UsersController _usersController;

        public UsersControllerTests()
        {
            _loggerServiceMock = new Mock<ILoggerService>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _usersController = new UsersController(_loggerServiceMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOkObjectResult_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId, Email = "test@example.com" };
            _userRepositoryMock.Setup(r => r.GetUserById(userId)).ReturnsAsync(user);

            // Act
            var result = await _usersController.GetById(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(userId, returnedUser.Id);
        }

        [Fact]
        public async Task GetById_ReturnsBadRequestObjectResult_WhenUserDoesNotExist()
        {
            // Arrange
            var userId = 1;
            _userRepositoryMock.Setup(r => r.GetUserById(userId)).ReturnsAsync(null as User);

            // Act
            var result = await _usersController.GetById(userId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("User does not exist.", badRequestResult.Value);
        }

        [Fact]
        public async Task GetByEmail_ReturnsOkObjectResult_WhenUserExists()
        {
            // Arrange
            var userEmail = "test@example.com";
            var user = new User { Id = 1, Email = userEmail };
            _userRepositoryMock.Setup(r => r.GetUserByEmail(userEmail)).ReturnsAsync(user);

            // Act
            var result = await _usersController.GetByEmail(userEmail);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<User>(okResult.Value);
            Assert.Equal(userEmail, returnedUser.Email);
        }

        [Fact]
        public async Task GetByEmail_ReturnsBadRequestObjectResult_WhenUserDoesNotExist()
        {
            // Arrange
            var userEmail = "test@example.com";
            _userRepositoryMock.Setup(r => r.GetUserByEmail(userEmail)).ReturnsAsync(null as User);

            // Act
            var result = await _usersController.GetByEmail(userEmail);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("User does not exist.", badRequestResult.Value);
        }

        [Fact]
        public async Task UpdateUser_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _usersController.ModelState.AddModelError("InvalidModel", "Test");

            // Act
            var result = await _usersController.Put("test@example.com", new UserEditViewModel());

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateUser_ShouldReturnBadRequest_WhenUserDoesNotExist()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync((User)null);

            // Act
            var result = await _usersController.Put("test@example.com", new UserEditViewModel());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateUser_ShouldReturnOk_WhenUserIsUpdatedSuccessfully()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetUserByEmail(It.IsAny<string>()))
                .ReturnsAsync(new User { Id = 1, Email = "test@example.com" });

            var userEditViewModel = new UserEditViewModel
            {
                Name = "John",
                SureName = "Doe",
                Email = "test@example.com",
                Preferences = "Drama, Comedy"
            };

            // Act
            var result = await _usersController.Put("test@example.com", userEditViewModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            _userRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
            _userRepositoryMock.Verify(x => x.CommitChanges(), Times.Once);
        }
    }
}

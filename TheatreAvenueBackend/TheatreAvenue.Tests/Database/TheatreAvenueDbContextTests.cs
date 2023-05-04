using Microsoft.EntityFrameworkCore;
using TheatreAvenue.Database;
using Xunit;

public class TheatreAvenueDbContextTests
{
    private DbContextOptions<TheatreAvenueDbContext> _options;

    [Fact]
    public void Constructor_WithNoArgs_CreatesDbContextWithDefaultOptions()
    {
        // Arrange

        // Act
        var context = new TheatreAvenueDbContext();

        // Assert
        Assert.NotNull(context);
    }

    [Fact]
    public void Constructor_WithOptions_CreatesDbContextWithSpecifiedOptions()
    {
        // Arrange
        _options = new DbContextOptionsBuilder<TheatreAvenueDbContext>()
            .UseInMemoryDatabase(databaseName: "test_db")
            .Options;

        // Act
        var context = new TheatreAvenueDbContext(_options);

        // Assert
        Assert.NotNull(context);
        Assert.IsType<TheatreAvenueDbContext>(context);
    }

    [Fact]
    public void DbSetProperties_ReturnsDbSetForAllEntities()
    {
        // Arrange
        _options = new DbContextOptionsBuilder<TheatreAvenueDbContext>()
            .UseInMemoryDatabase(databaseName: "test_db")
            .Options;

        using (var context = new TheatreAvenueDbContext(_options))
        {
            // Act
            var users = context.Users;
            var theatreEvents = context.TheatreEvents;
            var venues = context.Venues;
            var seats = context.Seats;
            var locations = context.Locations;

            // Assert
            Assert.NotNull(users);
            Assert.NotNull(theatreEvents);
            Assert.NotNull(venues);
            Assert.NotNull(seats);
            Assert.NotNull(locations);
        }
    }
}

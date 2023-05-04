using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TheatreAvenue.Database;
using TheatreAvenue.ML.Recommendations;
using TheatreAvenue.Models.DatabaseModels;
using Xunit;

namespace TheatreAvenue.Tests.Reccomendations
{
    public class ReccomendedSeatsTests
    {
        private List<Seat> GetTestSeats()
        {
            return new List<Seat>
            {
                new Seat { Id = 1, Number = 1, Row = 1, Booked = true, UserId = 1 },
                new Seat { Id = 2, Number = 2, Row = 1, Booked = false, UserId = null },
                new Seat { Id = 3, Number = 3, Row = 1, Booked = true, UserId = 1 },
                new Seat { Id = 4, Number = 4, Row = 1, Booked = true, UserId = 2 },
                new Seat { Id = 5, Number = 5, Row = 1, Booked = false, UserId = null },
            };
        }

        private TheatreAvenueDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<TheatreAvenueDbContext>()
                .UseInMemoryDatabase(databaseName: "TheatreAvenueDb")
                .Options;

            var dbContext = new TheatreAvenueDbContext(options);
            dbContext.Seats.AddRange(GetTestSeats());
            dbContext.SaveChanges();

            return dbContext;
        }

        [Fact]
        public async void GetReccomendedSeats_ReturnsBookedSeatsForUser()
        {
            // Arrange
            int userId = 1;
            var dbContext = GetDbContext();
            var reccomenedSeats = new RecommenedSeats(dbContext);

            // Act
            List<int> recommendedSeatNumbers = await reccomenedSeats.GetReccomendedSeats(userId);

            // Assert
            Assert.Equal(3, recommendedSeatNumbers.Count);
            Assert.Contains(1, recommendedSeatNumbers);
            Assert.Contains(29, recommendedSeatNumbers);
        }
    }
}

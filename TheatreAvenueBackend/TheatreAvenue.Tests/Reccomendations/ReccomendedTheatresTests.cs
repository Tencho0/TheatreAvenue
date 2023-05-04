using System.Collections.Generic;
using TheatreAvenue.Database;
using TheatreAvenue.ML.Recommendations;
using TheatreAvenue.Models.DatabaseModels;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System;

namespace TheatreAvenue.Tests.Reccomendations
{
    public class ReccomenedTheatresTests
    {
        private List<TheatreEvent> GetTestTheatreEvents()
        {
            return new List<TheatreEvent>
            {
                new TheatreEvent { Id = 1, Genre = "Drama", Name = "Drama Event 1", Description = "Drama Event 1 Description", VenueId = 1, Image = "drama1.jpg", Actors = "Actor1, Actor2", TicketPrice = 50, StartTime = DateTime.Now },
                new TheatreEvent { Id = 2, Genre = "Comedy", Name = "Comedy Event 1", Description = "Comedy Event 1 Description", VenueId = 2, Image = "comedy1.jpg", Actors = "Actor3, Actor4", TicketPrice = 40, StartTime = DateTime.Now },
                new TheatreEvent { Id = 3, Genre = "Drama", Name = "Drama Event 2", Description = "Drama Event 2 Description", VenueId = 1, Image = "drama2.jpg", Actors = "Actor1, Actor2", TicketPrice = 60, StartTime = DateTime.Now },
                new TheatreEvent { Id = 4, Genre = "Action", Name = "Action Event 1", Description = "Action Event 1 Description", VenueId = 3, Image = "action1.jpg", Actors = "Actor5, Actor6", TicketPrice = 70, StartTime = DateTime.Now },
                new TheatreEvent { Id = 5, Genre = "Drama", Name = "Drama Event 3", Description = "Drama Event 3 Description", VenueId = 1, Image = "drama3.jpg", Actors = "Actor1, Actor2", TicketPrice = 55, StartTime = DateTime.Now },
            };
        }

        private TheatreAvenueDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<TheatreAvenueDbContext>()
                .UseInMemoryDatabase(databaseName: "TheatreAvenueDb")
                .Options;

            var dbContext = new TheatreAvenueDbContext(options);
            dbContext.TheatreEvents.AddRange(GetTestTheatreEvents());
            dbContext.SaveChanges();

            return dbContext;
        }

        [Fact]
        public async void GetReccomendedTheatres_ReturnsTheatreEventsForUserGenrePreferences()
        {
            // Arrange
            string userGenrePreferences = "Drama Comedy";
            var dbContext = GetDbContext();
            var reccomenedTheatres = new RecommenedTheatres(dbContext);

            // Act
            List<TheatreEvent> recommendedTheatreEvents = await reccomenedTheatres.GetReccomendedTheatres(userGenrePreferences);

            // Assert
            Assert.Equal(3, recommendedTheatreEvents.Count);
            Assert.All(recommendedTheatreEvents, te => Assert.Contains(te.Genre, userGenrePreferences));
        }
    }
}


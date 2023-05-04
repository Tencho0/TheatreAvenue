using System.Collections.Generic;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models
{
    // Represents user data extracted from the database
    public class UserData
    {
        // User email address
        public string Email { get; set; }

        // String containing comma-separated IDs of all the theatre events the user has booked
        public string BookedTheatreEventsIds { get; set; }

        public List<TheatreEvent> ReccomendedTheatreEvents { get; set; }

        public List<int> ReccomendedSeatNumbers { get; set; }

        public string Preferences { get; set; }

        // Flag indicating whether the user has admin privileges or not
        public bool IsAdmin { get; set; }
    }
}

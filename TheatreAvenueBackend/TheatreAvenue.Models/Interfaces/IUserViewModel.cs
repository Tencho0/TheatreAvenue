using System.Collections.Generic;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface IUserViewModel
    {
        string UniqueToken { get; set; }

        string Name { get; set; }

        string SureName { get; set; }

        string Email { get; set; }

        string BookedTheatreEventsIds { get; set; }

        bool IsAdmin { get; set; }

        string Preferences { get; set; }
    }
}

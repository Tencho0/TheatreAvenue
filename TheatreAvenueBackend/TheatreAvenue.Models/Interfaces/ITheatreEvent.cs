using System;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface ITheatreEvent
    {
        string Name { get; set; }

        string Description { get; set; }

        Venue Venue { get; set; }

        string Genre { get; set; }

        string Image { get; set; }
        
        string Actors { get; set; }

        double TicketPrice { get; set; }

        DateTime StartTime { get; set; }
    }
}

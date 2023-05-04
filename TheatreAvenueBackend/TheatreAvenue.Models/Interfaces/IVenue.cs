using System.Collections.Generic;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.Interfaces
{
    public interface IVenue
    {
        int Id { get; set; }

        string Name { get; set; }

        Location Location { get; set; }

        List<Seat> Seats { get; set; }
    }
}

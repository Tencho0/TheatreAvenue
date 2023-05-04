using System.Collections.Generic;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.ViewModels
{
    public  class BoockedTheatreEventResponseData
    {
        public BoockedTheatreEventResponseData(TheatreEvent bookedTheatreEvent, List<int> reccomendedSeats)
        {
            BookedTheatreEvent = bookedTheatreEvent;
            
            ReccomendedSeats = reccomendedSeats;
        }

        public TheatreEvent BookedTheatreEvent { get; set; }
        public List<int> ReccomendedSeats { get; set; }
    }
}

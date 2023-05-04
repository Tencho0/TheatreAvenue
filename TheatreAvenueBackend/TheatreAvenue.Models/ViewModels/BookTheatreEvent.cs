
using System.Collections.Generic;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for booking a theatre event
    public class BookTheatreEvent
    {
        //List of selected seats by the user
        public List<string> SelectedSeats { get; set; }
        //Theatre event ID
        public int TheatreEventId { get; set; }
        //User email
        public string UserEmail { get; set; }
    }
}

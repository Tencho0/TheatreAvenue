using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for the venue view
    public class VenueViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Seats are required")]
        public List<Seat> Seats { get; set; }
    }
}

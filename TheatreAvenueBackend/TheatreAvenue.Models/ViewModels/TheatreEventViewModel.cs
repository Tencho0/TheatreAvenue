using System;
using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for the theatre event view
    public class TheatreEventViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Venue is required")]
        public Venue Venue { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Actors is required")]
        public string Actors { get; set; }

        [Required(ErrorMessage = "TicketPrice is required")]
        public double TicketPrice { get; set; }

        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { get; set; }
    }
}

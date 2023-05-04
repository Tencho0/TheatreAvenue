using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.DatabaseModels
{
    // Represents a theatre event that can be booked
    [Table("TheatreEvents")]
    public class TheatreEvent : ITheatreEvent, IEntityBase
    {
        // The unique identifier for the theatre event
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // The name of the theatre event
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        // The description of the theatre event
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        // The unique identifier of the venue where the theatre event takes place
        [Required(ErrorMessage = "Venue is required")]
        public int VenueId { get; set; }

        // The venue where the theatre event takes place
        public Venue Venue { get; set; }

        // The genre of the theatre event
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        // The image URL of the theatre event
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        // The actors of the theatre event
        [Required(ErrorMessage = "Actors is required")]
        public string Actors { get; set; }

        // The price of a ticket for the theatre event
        [Required(ErrorMessage = "TicketPrice is required")]
        public double TicketPrice { get; set; }

        // The start time of the theatre event
        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { get; set; }
    }
}

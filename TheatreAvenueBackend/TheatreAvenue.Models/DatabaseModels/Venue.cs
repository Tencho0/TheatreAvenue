using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.DatabaseModels
{
    [Table("Venues")]
    public class Venue: IVenue, IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //integer that uniquely identifies the venue record in the database.

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } //a string that specifies the name of the venue.

        [Required(ErrorMessage = "Location is required")]
        public int LocationId { get; set; } //integer that references the id of the location record associated with the venue.
        public Location Location { get; set; } // a navigation property that references the location record associated with the venue.

        //used to specify that certain properties must have a value
        [Required(ErrorMessage = "Seats are required")]
        public List<Seat> Seats { get; set; } //a list of Seat objects that represent the seats available in the venue.

    }
}

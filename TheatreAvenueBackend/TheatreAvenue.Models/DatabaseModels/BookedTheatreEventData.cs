
using System.ComponentModel.DataAnnotations;

namespace TheatreAvenue.Models.DatabaseModels
{
    public class BookedTheatreEventData
    {
        [Key] // used to mark Id as the primary key of the table.
        public int Id { get; set; } // indicates that this property is the primary key of the corresponding database table
        public TheatreEvent TheatreEvent { get; set; } // refers to the actual theatre event being booked
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.DatabaseModels
{
    // Specifying the table name for the entity
    [Table("Users")]
    public class User : IUser, IEntityBase
    {
        // Primary key for the entity
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // User's unique token
        [Required(ErrorMessage = "UniqueToken is required")]
        public string UniqueToken { get; set; }

        // User's name
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        // User's surname
        [Required(ErrorMessage = "SureName is required")]
        public string SureName { get; set; }

        // User's email address
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        // User's password
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        // IDs of the theatre events that the user has booked
        public string BookedTheatreEventsIds { get; set; }

        // Whether the user is an admin or not
        public bool IsAdmin { get; set; }

        // User's preferences
        public string Preferences { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.DatabaseModels;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for the user view
    public class UserViewModel: IUserViewModel
    {
        [Required(ErrorMessage = "UniqueToken is required")]
        [StringLength(60, ErrorMessage = "UniqueToken can't be longer than 60 characters")]
        public string UniqueToken { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string SureName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string BookedTheatreEventsIds { get; set; }

        public bool IsAdmin { get; set; }

        public string Preferences { get; set; }
    }
}

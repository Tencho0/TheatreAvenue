using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for the user edit view
    public class UserEditViewModel : IUserEditViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SureName is required")]
        public string SureName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preferences is required")]
        public string Preferences { get; set; }
    }
}

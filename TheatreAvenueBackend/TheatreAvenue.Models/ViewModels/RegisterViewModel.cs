using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for registering
    public class RegisterViewModel : IRegisterViewModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string SureName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string GenrePreferences { get; set; }

        public bool IsAdmin { get; set; }
    }
}

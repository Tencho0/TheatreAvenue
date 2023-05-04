using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for login
    public class LoginViewModel : ILoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.Interfaces;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for the user admin view
    public class UserAdminViewModel : IUserAdminViewModel
    {
        [Required(ErrorMessage = "UniqueToken is required")]
        public string UniqueToken { get; set; }

        [Required(ErrorMessage = "IsAdmin is required")]
        public bool IsAdmin { get; set; }
    }
}

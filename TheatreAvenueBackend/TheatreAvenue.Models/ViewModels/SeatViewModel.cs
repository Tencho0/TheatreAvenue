using System.ComponentModel.DataAnnotations;
using TheatreAvenue.Models.DatabaseModels;

namespace TheatreAvenue.Models.ViewModels
{
    //ViewModel for the seat view
    public class SeatViewModel
    {
        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Row is required")]
        public int Row { get; set; }

        [Required(ErrorMessage = "Booked is required")]
        public bool Booked { get; set; }

        public User User { get; set; }
    }
}
